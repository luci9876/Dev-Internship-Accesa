import './UserLeaderboard.scss';
import { FormattedMessage } from "react-intl"
import LeadeboardRow from "./LeaderboardRow"
import { Trainee } from '../../models/Trainee';
import { useCallback, useEffect, useState } from 'react';
import TraineeService from '../../services/TraineeService';
import { DEFAULT_ERROR, ResponseError } from '../../models/Response';
import ErrorMessage from '../ErrorMessage/ErrorMessage';
import Loader from '../Loader/Loader';

const UserLeaderboard = () => {
    const [users, setUsers] = useState<Trainee[]>([]);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);
    const [isLoading, setIsLoading] = useState(true);

    const getUsersScore = useCallback(async () => {
        const response = await TraineeService.getTraineesScore();
        if (!response.hasError) {
            setUsers(response.data);
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

        getUsersScore();

    }, [getUsersScore])

    return (
        isLoading ?
            <Loader /> :
            hasError ?
            <ErrorMessage responseError={error} />
            : <div className="sb-user-leaderboard-page-full">
            <div className="sb-user-leaderboard-page">
                <div className='sb-profile-title'>
                    <h2>
                        <FormattedMessage
                            id='app.user.leaderboard.page.title'
                            defaultMessage='User Leaderboard' />
                    </h2>
                </div>
                <table className="sb-user-leaderboard-table">
                    <thead>
                        <tr>
                            <th>Place</th>
                            <th>Name</th>
                            <th>Score</th>
                        </tr>
                    </thead>
                    <tbody>
                        {users.map((user, index) => <LeadeboardRow user={user} place={index + 1} key={user.id} />)}
                    </tbody>
                </table>
            </div>
            </div>
    )
}

export default UserLeaderboard