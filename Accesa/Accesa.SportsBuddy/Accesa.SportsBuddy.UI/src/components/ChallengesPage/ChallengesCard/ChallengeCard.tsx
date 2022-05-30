import './ChallengeCard.scss';
import { Challenge, ChallengeExtended } from '../../../models/Challenge';
import { FormattedMessage, useIntl } from 'react-intl';
import { DefaultButton } from '@fluentui/react';
import ExtendedChallengeService from "../../../services/ExtendedChallengeService";
import { useEffect, useState } from 'react';

import { useHistory } from 'react-router-dom';
import ChallengeService from '../../../services/ChallengeService';
import SuccessMessage from '../../SuccessMessage/SuccessMessage';

export interface ChallengeProps {
    challenge: Challenge,
    isOnMyChallanges: boolean,
    deleteChallenge?: any,
    availableChallenges?: ChallengeExtended[]
}

const ChallengeCard: React.FC<ChallengeProps> = ({ challenge, isOnMyChallanges, deleteChallenge, availableChallenges }) => {
    const intl = useIntl();
    const history = useHistory();
    const [shouldShowSuccessMessage, setShouldShowSuccessMessage] = useState(false);
    const [userChallenges, setUserChallenges] = useState<ChallengeExtended[]>([])

    useEffect(() => {
        setUserChallenges(availableChallenges!);
    }, [availableChallenges])
    const user = JSON.parse(localStorage.getItem('User')!)

    const addedChallenge: ChallengeExtended = {
        challengeId: challenge.id,
        traineeId: user.id,
        proof: '',
        startDate: new Date(),
        endDate: null,
        isFinished: false,
    }

    const isAvailable = () => {
        return userChallenges.filter((e: ChallengeExtended) => e.challengeId === challenge.id).length > 0;
    }

    const addChallenge = async () => {
        await ExtendedChallengeService.addChallenge(addedChallenge);
        setShouldShowSuccessMessage(true);
        setTimeout(() => {
            setShouldShowSuccessMessage(false);
        }, 800);
    }

    const handleDeletion = async () => {
        await ChallengeService.deleteChallenge(challenge.id);
        deleteChallenge(challenge.id)
    }

    return (
        <div className={isOnMyChallanges ? 'sb-my-challenges-card' : 'sb-challange-card'}>
            <div className='sb-challege-card-descripiton'>
                <h2>{challenge.title}</h2>
                <p><strong><FormattedMessage
                    id='app.challenge.card.description'
                    defaultMessage='Description' />:</strong>{challenge.description}</p>
                <p><strong><FormattedMessage
                    id='app.challenge.card.goal'
                    defaultMessage='Goal' />:</strong>{challenge.trackedOutcome}</p>
            </div>
            {isOnMyChallanges ?
                <div className="sb-extended-challenge-buttons">
                    <DefaultButton
                        text={intl.formatMessage({ id: "app.challenges.btn.editChallenge" })}
                        onClick={() => history.push(`/edit-challenge/${challenge.id}`)} />
                    <DefaultButton
                        className="sb-extended-challenge-buttons-delete"
                        text={intl.formatMessage({ id: "app.challenges.btn.deleteChallenge" })}
                        onClick={handleDeletion} />
                </div>
                :
                <div>
                    <DefaultButton
                        text={intl.formatMessage({ id: "app.challenges.btn.tryChallenge" })}
                        onClick={addChallenge}
                        disabled={isAvailable()}
                    />
                    <SuccessMessage shouldShowSuccessMessage={shouldShowSuccessMessage} id="app.challenge.card.success" />
                </div>}

        </div>
    )
}

export default ChallengeCard
