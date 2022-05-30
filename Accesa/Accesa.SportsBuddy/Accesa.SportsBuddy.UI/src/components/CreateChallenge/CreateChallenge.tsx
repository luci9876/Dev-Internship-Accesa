import './CreateChallenge.scss';
import { useIntl, FormattedMessage } from 'react-intl';
import { DefaultButton, TextField } from '@fluentui/react';
import { Challenge, DEFAULT_CHALLANGE } from '../../models/Challenge';
import { useState } from 'react';
import FieldValidatorService from '../../services/FieldValidatorService';
import { useHistory } from 'react-router-dom';
import ChallengeService from '../../services/ChallengeService';
import { TRAINEE_ID } from '../../models/TestConstants';
import SuccessMessage from '../SuccessMessage/SuccessMessage';

const CreateChallenge = () => {
    const intl = useIntl();
    const [challengeInfo, setChallengeInfo] = useState<Challenge>(DEFAULT_CHALLANGE);
    const history = useHistory();
    const author = JSON.parse(localStorage.getItem('User')!)
    const [shouldShowSuccessMessage, setShouldShowSuccessMesssage] = useState(false);

    const validateLength = (value: string) => {
        return FieldValidatorService.validateFieldLength(value);
    }
    const formValid = challengeInfo.title && challengeInfo.description && challengeInfo.trackedOutcome

    const handleCreation = async () => {
        challengeInfo.authorId = author.id;
        if (formValid) {
            await ChallengeService.addChallenge(challengeInfo);
            setShouldShowSuccessMesssage(true);
            setTimeout(() => {
                setShouldShowSuccessMesssage(false);
            }, 2000);
        }
        history.push('/my-challenges');
    }

    return (
        <div className='sb-create-challenge-page'>
            <div className="sb-challenge-title">
                <h2>
                    <FormattedMessage
                        id="app.createChallenge.title"
                        defaultMessage="Edit Profile" />
                </h2>
                <DefaultButton
                    text={intl.formatMessage({ id: 'app.challenges.btn.myChallenges' })}
                    onClick={() => history.push('/my-challenges')} />
            </div>
            <form className="sb-user-form">
                <TextField
                    label={intl.formatMessage({ id: "app.createChallenge.challenge.title" })}
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
                <div className="sb-challenge-button">
                    <DefaultButton
                        text={intl.formatMessage({ id: "app.challenges.btn.createChallenge" })}
                        disabled={!formValid}
                        onClick={handleCreation}
                    />
                    <SuccessMessage shouldShowSuccessMessage={shouldShowSuccessMessage} id={"app.challenge.creation.success"} />
                </div>
            </form>
        </div>
    )
}

export default CreateChallenge
