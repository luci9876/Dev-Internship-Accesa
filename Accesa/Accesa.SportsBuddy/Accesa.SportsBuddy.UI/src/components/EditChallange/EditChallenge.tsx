import '../CreateChallenge/CreateChallenge.scss';
import { useIntl, FormattedMessage } from 'react-intl';
import { DefaultButton, TextField } from '@fluentui/react';
import { Challenge, DEFAULT_CHALLANGE } from '../../models/Challenge';
import { useCallback, useEffect, useState } from 'react';
import FieldValidatorService from '../../services/FieldValidatorService';
import { useHistory } from 'react-router-dom';
import ChallengeService from '../../services/ChallengeService';
import { DEFAULT_ERROR, ResponseError } from '../../models/Response';
import ErrorMessage from '../ErrorMessage/ErrorMessage';

const EditChallenge = () => {
    const intl = useIntl();
    const [challengeInfo, setChallengeInfo] = useState<Challenge>(DEFAULT_CHALLANGE);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);
    const history = useHistory();

    let urlElements = window.location.href.split("/");
    let challengeId = parseInt(urlElements[urlElements.length - 1], 10);

    const getChallenge = useCallback(async () => {
        const response = await ChallengeService.getChallengeById(challengeId);
        if (!response.hasError) {
            setChallengeInfo(response.data);
            setHasError(response.hasError);
        }
        else {
            setError({
                errorCode: response.errorCode,
                errorMessage: response.errorMessage
            })
            setHasError(response.hasError);
        }
    }, [challengeId])

    useEffect(() => {

        getChallenge();

    }, [getChallenge])

    const handleUpdate = async () => {
        if (formValid) {
            await ChallengeService.updateChallenge(challengeInfo);
            history.push('/my-challenges');
        }
    }

    const validateLength = (value: string) => {
        return FieldValidatorService.validateFieldLength(value);
    }
    const formValid = challengeInfo.title && challengeInfo.description && challengeInfo.trackedOutcome

    return (
        hasError ?
            <ErrorMessage responseError={error} />
            : <div className='sb-create-challenge-page'>
                <div className="sb-challenge-title">
                    <h2>
                        <FormattedMessage
                            id="app.editChallenge.challenge.title"
                            defaultMessage="Edit Profile" />
                    </h2>
                    <DefaultButton
                        text={intl.formatMessage({ id: 'app.challenges.btn.myChallenges' })}
                        onClick={() => history.push('/my-challenges')} />
                </div>
                <form className="sb-user-form">
                    <TextField
                        label={intl.formatMessage({ id: "app.editChallenge.challenge.title" })}
                        value={challengeInfo.title}
                        placeholder={intl.formatMessage({ id: "app.createChallenge.challenge.title" })}
                        onChange={(e, newValue) => setChallengeInfo({ ...challengeInfo, title: newValue ?? '' })}
                        validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(challengeInfo.title)}
                        required />
                    <TextField
                        label={intl.formatMessage({ id: "app.createChallenge.challenge.description" })}
                        value={challengeInfo.description}
                        multiline={true}
                        placeholder={intl.formatMessage({ id: "app.createChallenge.challenge.description" })}
                        onChange={(e, newValue) => setChallengeInfo({ ...challengeInfo, description: newValue ?? '' })}
                        validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(challengeInfo.description)}
                        required />
                    <TextField
                        label={intl.formatMessage({ id: "app.createChallenge.challenge.outcome" })}
                        value={challengeInfo.trackedOutcome}
                        placeholder={intl.formatMessage({ id: "app.createChallenge.challenge.outcome" })}
                        onChange={(e, newValue) => setChallengeInfo({ ...challengeInfo, trackedOutcome: newValue ?? '' })}
                        validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(challengeInfo.trackedOutcome)}
                        required />
                    <div className="sb-profile-buttons">
                        <DefaultButton
                            text={intl.formatMessage({ id: "app.challenges.btn.editChallenge" })}
                            disabled={!formValid}
                            onClick={handleUpdate}
                        />
                    </div>
                </form>
            </div>
    )
}

export default EditChallenge
