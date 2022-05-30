import { useCallback, useEffect, useState } from 'react';
import '../../ActivityCard/ActivityCard.scss';
import './UserMainPage.scss'
import ActivityCard from '../../ActivityCard/ActivityCard';
import TrainingProgramService from '../../../services/TrainingProgramService';
import { useIntl } from 'react-intl';
import Carousel from 'react-elastic-carousel';
import { TrainingProgram } from '../../../models/TrainingProgram';
import { DEFAULT_ERROR, ResponseError } from '../../../models/Response';
import ErrorMessage from '../../ErrorMessage/ErrorMessage';
import Loader from '../../Loader/Loader';

function UserMainPage() {
    const [trainingPrograms, setTrainingPrograms] = useState<TrainingProgram[]>([]);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);
    const [isLoading, setIsLoading] = useState(true);
    const intl = useIntl();

    const isUserMainPage = localStorage.getItem("accountExists") ? true : false;//temporary until login token
    const isLogged = localStorage.getItem("accountExists") === "true";

    const getTraningsInfo = useCallback(async () => {
        const trainings = await TrainingProgramService.getTraningsInfo();
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
    }, []);

    useEffect(() => {

        getTraningsInfo();

    }, [getTraningsInfo])

    const breakPoints = [
        { width: 1, itemsToShow: 1, itemsToScroll: 1 },
        { width: 750, itemsToShow: 3, itemsToScroll: 1 },
        { width: 1500, itemsToShow: 3, itemsToScroll: 1 },
    ]

    return (
        isLoading ?
            <Loader /> :
            hasError ?
                <ErrorMessage responseError={error} />
                : <div className="sb-user-main-page-full">
                    <div className={isLogged ? "sb-user-main-page" : "sb-user-landing-page"}>
                        <h1 className="sb-user-main-page__suggested">{intl.formatMessage({ id: "app.userMainPage.suggestedTrainings" })}</h1>
                        <section className="sb-cards-display">
                            <Carousel breakPoints={breakPoints} isRTL={false}>
                                {trainingPrograms.map((element: any) => (<ActivityCard element={element} key={element.trainingProgramId} isUserMainPage={isUserMainPage} />))}
                            </Carousel>
                        </section>
                    </div>
                </div>
    )
}

export default UserMainPage;
