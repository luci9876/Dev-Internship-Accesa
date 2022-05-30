import './ChallengesPage.scss';
import { Challenge, ChallengeExtended } from '../../models/Challenge';
import ChallengeCard from './ChallengesCard/ChallengeCard';
import { FormattedMessage, useIntl } from 'react-intl';
import { DefaultButton } from '@fluentui/react';
import { useHistory } from 'react-router-dom';
import { useCallback, useEffect, useState } from 'react';
import ChallengeService from '../../services/ChallengeService';
import { DEFAULT_ERROR, ResponseError } from '../../models/Response';
import ErrorMessage from '../ErrorMessage/ErrorMessage';
import Loader from '../Loader/Loader';
import ExtendedChallengeService from '../../services/ExtendedChallengeService';

const ChallengesPage = () => {
    const [challenges, setChallenges] = useState<Challenge[]>([]);
    const [availableChallenges, setAvailableChallenges] = useState<ChallengeExtended[]>([]);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);
    const [isLoading, setIsLoading] = useState(true);
    const intl = useIntl();
    const history = useHistory();

    const getChallenges = useCallback(async () => {
        const response = await ChallengeService.getAllChallenges();
        if (!response.hasError) {
            setChallenges(response.data);
            setHasError(response.hasError);
            setIsLoading(false);
            return;
        }

        setError({
            errorCode: response.errorCode,
            errorMessage: response.errorMessage
        })
        setHasError(response.hasError);
        setIsLoading(false);

    }, [])

    const getActiveChallenges = useCallback(async () => {
        const response = await ExtendedChallengeService.getAllChallenges();
        if (!response.hasError) {
            setAvailableChallenges(response.data);
            setHasError(response.hasError);
            return;
        }

        setError({
            errorCode: response.errorCode,
            errorMessage: response.errorMessage
        })
        setHasError(response.hasError);

    }, [])

    useEffect(() => {

        getChallenges();
        getActiveChallenges();


    }, [getChallenges, getActiveChallenges])

    return (
        isLoading ?
            <Loader /> :
            hasError ?
                <ErrorMessage responseError={error} />
                : <div className='sb-challenge-page-full'>
                    <div className='sb-challenge-page'>
                        <div className='sb-profile-title'>
                            <h2>
                                <FormattedMessage
                                    id='app.challenges-page.title'
                                    defaultMessage='Available Challenges' />
                            </h2>
                            <DefaultButton
                                text={intl.formatMessage({ id: 'app.challenges.btn.myChallenges' })}
                                onClick={() => history.push('/my-challenges')} />
                        </div>
                        {challenges.map((challenge: Challenge) => <ChallengeCard challenge={challenge} isOnMyChallanges={false} key={challenge.id} availableChallenges={availableChallenges} />)}
                    </div>
                </div>
    )
}

export default ChallengesPage
