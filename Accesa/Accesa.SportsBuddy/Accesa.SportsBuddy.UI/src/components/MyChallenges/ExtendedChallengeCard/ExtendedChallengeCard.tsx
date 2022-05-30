import './ExtendedChallengeCard.scss';
import { Challenge, ChallengeExtended, DEFAULT_CHALLANGE } from '../../../models/Challenge';
import { FormattedMessage, useIntl } from 'react-intl';
import { DefaultButton } from '@fluentui/react';
import moment from 'moment';
import { useCallback, useEffect, useState } from 'react';
import ExtendedChallengeService from '../../../services/ExtendedChallengeService';
import ChallengeService from '../../../services/ChallengeService';
import TraineeService from '../../../services/TraineeService';
import { DEFAULT_ERROR, ResponseError } from '../../../models/Response';
import ErrorMessage from '../../ErrorMessage/ErrorMessage';
import { useHistory } from 'react-router-dom';
export interface ChallengeProps {
    challengeExtended: ChallengeExtended,
    deleteChallange: any
}

const ExtendedChallengeCard: React.FC<ChallengeProps> = ({ challengeExtended, deleteChallange }) => {
    const [challenge, setChallenge] = useState<Challenge>(DEFAULT_CHALLANGE);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);
    const intl = useIntl();
    const history = useHistory();
    const user = JSON.parse(localStorage.getItem('User')!)

    const getChallenge = useCallback(async () => {
        const response = await ChallengeService.getChallengeById(challengeExtended.challengeId);
        if (!response.hasError) {
            setChallenge(response.data);
            setHasError(response.hasError);
        }
        else {
            setError({
                errorCode: response.errorCode,
                errorMessage: response.errorMessage
            })
            setHasError(response.hasError);
        }
    }, [challengeExtended.challengeId])

    useEffect(() => {

        getChallenge();

    }, [getChallenge])

    const handleDeletion = async () => {
        await ExtendedChallengeService.deleteChallenge(user.id, challenge.id);
        deleteChallange(challengeExtended.challengeId)
    }

    const uploadProof = async () => {
        if (!challengeExtended.isFinished) {
            await ExtendedChallengeService.updateChallenge({
                traineeId: challengeExtended.traineeId,
                challengeId: challengeExtended.challengeId,
                proof: 'Challenge completed',
                startDate: challengeExtended.startDate,
                endDate: new Date(),
                isFinished: true
            })
            await TraineeService.updateTraineeScore(user.id);
        }
        history.go(0);
    }

    return (
        hasError ?
            <ErrorMessage responseError={error} />
            : <div className='sb-extended-challange-card'>
                <h2>{challenge.title}</h2>
                <div className='sb-challege-card-descripiton'>
                    <p><strong><FormattedMessage
                        id='app.challenge.card.description'
                        defaultMessage='Description' />:</strong>{challenge.description}</p>
                    <p><strong><FormattedMessage
                        id='app.challenge.card.goal'
                        defaultMessage='Goal' />:</strong>{challenge.trackedOutcome}</p>
                    <p><strong><FormattedMessage
                        id='app.challenge.card.startDate'
                        defaultMessage='Started at' />:</strong>{moment(`${challengeExtended.startDate}`).format('HH:MM DD.MM.YYYY')}</p>
                    <p><strong><FormattedMessage
                        id='app.challenge.card.endDate'
                        defaultMessage='Completed at' />:</strong>{challengeExtended.isFinished ? moment(`${challengeExtended.endDate}`).format('HH:MM DD.MM.YYYY') : 'Not finished yet'}</p>
                    <div className='sb-challenge-card-file-upload'>
                        <h5><FormattedMessage
                            id='app.challenge.card.proof'
                            defaultMessage='Proof of completion' />:</h5>
                        <input type="file" />
                        <DefaultButton
                            text={intl.formatMessage({ id: "app.challenges.btn.uploadProof" })}
                            onClick={uploadProof}
                            disabled={challengeExtended.isFinished} />
                    </div>
                    <img src="/trophy.png" alt={challengeExtended.isFinished ? 'completed' : 'not completed yet'} className={challengeExtended.isFinished ? '' : 'sb-challenge-completed'} />
                </div>
                <DefaultButton
                    className="sb-extended-challenge-buttons-delete"
                    text={intl.formatMessage({ id: "app.challenges.btn.removeChallenge" })}
                    onClick={handleDeletion} />
            </div>
    )
}

export default ExtendedChallengeCard
