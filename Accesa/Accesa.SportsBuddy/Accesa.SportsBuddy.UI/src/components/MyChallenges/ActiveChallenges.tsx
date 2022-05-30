import React, { useCallback, useEffect, useState } from 'react'
import { FormattedMessage } from 'react-intl';
import ExtendedChallengeCard from './ExtendedChallengeCard/ExtendedChallengeCard';
import Carousel from 'react-elastic-carousel';
import { ChallengeExtended } from '../../models/Challenge';
import ExtendedChallengeService from "../../services/ExtendedChallengeService"
import { DEFAULT_ERROR, ResponseError } from '../../models/Response';
import ErrorMessage from '../ErrorMessage/ErrorMessage';

const CreatedChallenges: React.FC = () => {
    const [challenges, setChallenges] = useState<ChallengeExtended[]>([]);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);    
    const user = JSON.parse(localStorage.getItem('User')!)

    const getActiveChallenges = useCallback(async () => {
        const response = await ExtendedChallengeService.getAllChallengesByTraineeId(user.id);
        if (!response.hasError) {
            setChallenges(response.data);
            setHasError(response.hasError);
        }
        else {
            setError({
                errorCode: response.errorCode,
                errorMessage: response.errorMessage
            })
            setHasError(response.hasError);
        }
    }, [])

    useEffect(() => {

        getActiveChallenges();

    }, [getActiveChallenges])

    const deleteChallange = (id: number) => {
        setChallenges(challenges.filter((challenge) => challenge.challengeId !== id))
    }

    const breakPoints = [
        { width: 1, itemsToShow: 1, itemsToScroll: 1 },
        { width: 750, itemsToShow: 2, itemsToScroll: 1 },
        { width: 1024, itemsToShow: 3, itemsToScroll: 1 },
        { width: 1200, itemsToShow: 4, itemsToScroll: 1 },
        { width: 1500, itemsToShow: 5, itemsToScroll: 1 },
    ]

    return (
        hasError ?
            <ErrorMessage responseError={error} />
            : <div className='sb-my-challenges-page'>
                <h2 className='sb-profile-title'>
                    <FormattedMessage
                        id='app.my.active.challenges.page.title'
                        defaultMessage='Active Challenges' />
                </h2>
                <div className='sb-my-challenges-container'>
                    <Carousel breakPoints={breakPoints} isRTL={false}>
                        {challenges.map((challenge: ChallengeExtended) => <ExtendedChallengeCard challengeExtended={challenge} deleteChallange={deleteChallange} key={challenge.challengeId} />)}
                    </Carousel>
                </div>
            </div>
    )
}

export default CreatedChallenges
