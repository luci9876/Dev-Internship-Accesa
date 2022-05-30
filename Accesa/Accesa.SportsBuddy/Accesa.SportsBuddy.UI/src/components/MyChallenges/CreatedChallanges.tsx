import { useCallback, useEffect, useState } from 'react'
import { DefaultButton } from '@fluentui/react';
import { FormattedMessage, useIntl } from 'react-intl';
import { Challenge, ChallengeExtended } from '../../models/Challenge';
import { useHistory } from 'react-router-dom';
import Carousel from 'react-elastic-carousel';
import ChallengeCard from '../ChallengesPage/ChallengesCard/ChallengeCard';
import ChallengeService from '../../services/ChallengeService';
import { TRAINEE_ID } from '../../models/TestConstants';
import { DEFAULT_ERROR, ResponseError } from '../../models/Response';
import ErrorMessage from '../ErrorMessage/ErrorMessage';
import Loader from '../Loader/Loader';

export interface ChallengeProps {
    challenges: ChallengeExtended[];
}

const CreatedChallanges = () => {
    const [challenges, setChallenges] = useState<Challenge[]>([]);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const intl = useIntl();
    const history = useHistory();
    const user = JSON.parse(localStorage.getItem('User')!)

    const getCreatedChallenges = useCallback(async () => {
        const response = await ChallengeService.getChallengeByAuthor(user.id);
        if (!response.hasError) {
            setChallenges(response.data);
            setHasError(response.hasError);
            setIsLoading(false);
        }
        else {
            setError({
                errorCode: response.errorCode,
                errorMessage: response.errorMessage
            })
            setHasError(response.hasError);
            setIsLoading(false);
        }
    }, [])

    useEffect(() => {

        getCreatedChallenges();

    }, [getCreatedChallenges])

    const deleteChallenge = (id: number) => {
        setChallenges(challenges.filter((challange) => challange.id !== id))
    }

    const breakPoints = [
        { width: 1, itemsToShow: 1, itemsToScroll: 1 },
        { width: 750, itemsToShow: 2, itemsToScroll: 1 },
        { width: 1024, itemsToShow: 3, itemsToScroll: 1 },
        { width: 1200, itemsToShow: 4, itemsToScroll: 1 },
        { width: 1500, itemsToShow: 5, itemsToScroll: 1 },
    ]

    return (
        isLoading ?
            <Loader /> :
            hasError ?
                <ErrorMessage responseError={error} />
                : <div className='sb-my-challenges-page'>
                    <div className='sb-profile-title'>
                        <h2>
                            <FormattedMessage
                                id='app.my-challenges-page.title'
                                defaultMessage='My Challenges' />
                        </h2>
                        <div>
                            <DefaultButton
                                className="sb-my-chellenges-create-btn"
                                text={intl.formatMessage({ id: 'app.challenges.btn.createChallenge' })}
                                onClick={() => history.push('/create-challenge')}
                            />
                            <DefaultButton
                                text={intl.formatMessage({ id: 'app.challenges.btn.allChallenges' })}
                                onClick={() => history.push('/challenges')}
                            />
                        </div>
                    </div>

                    {challenges.length === 0 ? <p>
                        <FormattedMessage
                            id='app.challenge.card.check'
                            defaultMessage='There are no challenges to display. Please create one!' /></p> :
                        <div className='sb-my-challenges-container'>
                            <Carousel breakPoints={breakPoints} isRTL={false}>
                                {challenges.map((challenge: Challenge) => <ChallengeCard challenge={challenge} key={challenge.id} deleteChallenge={deleteChallenge} isOnMyChallanges={true} />)}
                            </Carousel>
                        </div>}
                </div>
    )
}

export default CreatedChallanges
