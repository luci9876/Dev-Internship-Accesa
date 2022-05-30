import './ActivityDetails.scss';
import { useLocation } from 'react-router-dom';
import { useCallback, useEffect, useState } from 'react';
import ActivityInfo from "./ActivityInfo";
import Activity from "./Activity";
import { TrainingProgram } from '../../models/TrainingProgram';
import TrainingProgramService from '../../services/TrainingProgramService';
import { useIntl } from 'react-intl';
import ErrorMessage from '../ErrorMessage/ErrorMessage';
import { DEFAULT_ERROR, ResponseError } from '../../models/Response';
import Loader from '../Loader/Loader';

const ActivityPage = () => {

    const intl = useIntl();

    const [activityId, setActivityId] = useState(0);
    const [editMode, setEditMode] = useState(false);
    const [addMode, setAddMode] = useState(false);
    const [trainingProgram, setTrainingProgram] = useState<TrainingProgram>();
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);
    const [isLoading, setIsLoading] = useState(true);

    const location = useLocation();
    const loadingMessage = intl.formatMessage({ id: "app.activity.loading" })

    useEffect(() => {
        let locationId = location.pathname.split('/');
        let activityId: number = parseInt(locationId[locationId.length - 1]);
        setActivityId(activityId);
    }, [location])

    const handleEditMode = () => {
        setEditMode(!editMode);
    }

    const handleAddMode = () => {
        setAddMode(!editMode);
    }

    const GetTrainingInfoById = useCallback(async () => {
        setLoading(true);
        const training = await TrainingProgramService.GetTrainingInfoById(activityId);
        training && setLoading(false)
        if (!training.hasError) {
            setTrainingProgram(training.data);
            setHasError(training.hasError);
            setIsLoading(false);
        }
        else {
            setError({
                errorCode: training.errorCode,
                errorMessage: training.errorMessage
            })
            setHasError(training.hasError);
            setIsLoading(false);
        }
    }, [activityId]);

    useEffect(() => {
        activityId && GetTrainingInfoById();
    }, [activityId, GetTrainingInfoById])

    return (
        isLoading ?
            <Loader /> :
            hasError ?
                <ErrorMessage responseError={error} />
                : <div className="sb-activity-full-page">
                    {
                        !loading && trainingProgram && (editMode ? <Activity element={trainingProgram} /> : addMode ? <Activity /> : <ActivityInfo element={trainingProgram!} handleEditMode={handleEditMode} handleAddMode={handleAddMode} />)
                    }
                    {
                        loading && loadingMessage
                    }
                </div>
    )
}

export default ActivityPage;