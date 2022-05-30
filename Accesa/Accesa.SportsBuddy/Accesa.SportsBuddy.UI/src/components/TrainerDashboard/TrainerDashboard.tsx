import './TrainerDashboard.scss';
import ActivityCard from "../ActivityCard/ActivityCard";
import { useIntl } from 'react-intl';
import { FontIcon } from '@fluentui/react';
import { useHistory } from 'react-router-dom';
import { useCallback, useEffect, useState } from 'react';
import { TrainingProgram } from '../../models/TrainingProgram';
import TrainingProgramService from '../../services/TrainingProgramService';
import { TrainerData } from "../MockData/TrainersRawData";
import { UserRoleEnum } from '../../models/UserInfo';
import { DEFAULT_ERROR, ResponseError } from '../../models/Response';
import ErrorMessage from '../ErrorMessage/ErrorMessage';
import Loader from '../Loader/Loader';

const TrainerDashboard = () => {

    const intl = useIntl();
    const history = useHistory();

    const [trainingPrograms, setTrainingPrograms] = useState<TrainingProgram[]>([]);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);
    const [isLoading, setIsLoading] = useState(true);
    const user = JSON.parse(localStorage.getItem('User')!)

    const GetTrainingsInfoByTrainerId = useCallback(async () => {
        const trainings = await TrainingProgramService.GetTrainingsInfoByTrainerId(user.trainerId);
        if (!trainings.hasError) {
            setTrainingPrograms(trainings.data);
            setHasError(trainings.hasError);
            setIsLoading(false);
        }
        else {
            setError({
                errorCode: trainings.errorCode,
                errorMessage: trainings.errorMessage
            })
            setHasError(trainings.hasError);
            setIsLoading(false);
        }
    }, [user.trainerId]);


    useEffect(() => {
        GetTrainingsInfoByTrainerId();
    }, [GetTrainingsInfoByTrainerId])

    const handleAddTraining = () => {
        history.push("/add-activity");
    }

    return (
        isLoading ?
            <Loader /> :
            hasError ?
                <ErrorMessage responseError={error} />
                : <div className="sb-trainer-dashboard-outer">
                    <h1 className="sb-trainer-dashboard-title">{intl.formatMessage({ id: "app.trainer-dashboard-title" })}</h1>
                    {
                        (TrainerData.role.id === UserRoleEnum.TRAINER) &&
                        <FontIcon
                            className="sb-comment-add-icon"
                            aria-label="ChartIcon"
                            iconName="CircleAdditionSolid"
                            onClick={handleAddTraining} />
                    }
                    <section className="sb-trainer-dashboard">
                        {
                            trainingPrograms && trainingPrograms.length && trainingPrograms.map((element: any) => (<ActivityCard key={element.trainingProgramId} element={element} />))
                        }
                    </section>
                </div>

    )
}

export default TrainerDashboard;