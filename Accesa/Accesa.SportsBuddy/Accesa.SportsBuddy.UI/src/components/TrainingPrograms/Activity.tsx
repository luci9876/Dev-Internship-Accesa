import { useCallback, useEffect, useState } from 'react';
import { TrainingProgram } from '../../models/TrainingProgram';
import { TextField } from '@fluentui/react/lib/TextField';
import { DefaultButton, PrimaryButton } from '@fluentui/react/lib/Button';
import './Activity.scss';
import { Dropdown, FontIcon, IDropdownOption } from '@fluentui/react';
import FieldValidatorService from '../../services/FieldValidatorService';
import { useIntl } from 'react-intl';
import CenterService from '../../services/CenterService';
import TrainingProgramService from '../../services/TrainingProgramService';
import { SportsCenter } from "../../models/SportsCenter";
import { useHistory } from 'react-router-dom';
import { DEFAULT_ERROR, ResponseError } from '../../models/Response';
import ErrorMessage from '../ErrorMessage/ErrorMessage';

type ActivityUpdateProps = {
    element?: TrainingProgram
}

const Activity = (props: ActivityUpdateProps) => {

    const intl = useIntl();
    const history = useHistory();
    const user = JSON.parse(localStorage.getItem('User')!)

    const [newStep, setNewStep] = useState("");
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);
    const [sportCenters, setSportCenters] = useState<SportsCenter[]>([]);
    const [activityDetails, setActivityDetails] = useState<TrainingProgram>({
        trainingProgramId: 0,
        trainingProgramName: "",
        trainingProgramDifficulty: "",
        trainingProgramDescription: "",
        trainingProgramRecommendedSteps: [],
        trainingProgramDuration: "",
        trainingProgramLocation: intl.formatMessage({ id: "app.activity.location.option1" }),
        trainingProgramSportCenter: {
            id: 0,
            name: "",
            addressNavigation: {
                id: 0,
                street: "",
                city: "",
                state: "",
                postalCode: "",
                country: "",
                latitude: 0,
                longitude: 0
            }
        },
        trainer: {
            id: user.trainerId,
            userFirstName: user.firstName,
            userLastName: user.lastName,
            rating: user.rating
        },
        trainingProgramRating: 0,
    });

    const trainerFullName = `${user.firstName} ${user.lastName}`;

    const getAllSportCenters = useCallback(async () => {
        const sportCenters = await CenterService.getAllCenters();
        if (!sportCenters.hasError) {
            setSportCenters(sportCenters.data);
            setHasError(sportCenters.hasError);
        }
        else {
            setError({
                errorCode: sportCenters.errorCode,
                errorMessage: sportCenters.errorMessage
            })
            setHasError(sportCenters.hasError);
        }
    }, []);


    useEffect(() => {

        getAllSportCenters();

    }, [getAllSportCenters])


    useEffect(() => {
        props.element && setActivityDetails(activityDetails =>  activityDetails = {
            ...activityDetails,
            trainingProgramId: props.element!.trainingProgramId,
            trainingProgramName: props.element!.trainingProgramName,
            trainingProgramDifficulty: props.element!.trainingProgramDifficulty,
            trainingProgramDescription: props.element!.trainingProgramDescription,
            trainingProgramRecommendedSteps: props.element!.trainingProgramRecommendedSteps,
            trainingProgramDuration: props.element!.trainingProgramDuration,
            trainingProgramSportCenter: props.element!.trainingProgramSportCenter,
            trainer: props.element!.trainer,
            trainingProgramRating: props.element!.trainingProgramRating
        })
    }, [props.element])


    const centerOptions: IDropdownOption[] = sportCenters.map((element: SportsCenter) => { return { key: element.id!, text: element.name! } })

    const handleChangeSportCenter = (newValue: any) => {
        const key: number = +newValue!.key;
        const newSportCenter = sportCenters.filter((element: SportsCenter) => element.id === key)[0];
        setActivityDetails({ ...activityDetails, trainingProgramSportCenter: newSportCenter })
    }

    const options: IDropdownOption[] = [
        { key: 'beginner', text: intl.formatMessage({ id: "app.activity.difficulty-option1" }) },
        { key: 'intermediate', text: intl.formatMessage({ id: "app.activity.difficulty-option2" }) },
        { key: 'advanced', text: intl.formatMessage({ id: "app.activity.difficulty-option3" }) }
    ]

    const handleAddStep = (value: string) => {
        const steps = [...activityDetails.trainingProgramRecommendedSteps];
        steps.push(value);
        setActivityDetails({ ...activityDetails, trainingProgramRecommendedSteps: steps });
        setNewStep("");
    }
    const handleRemoveStep = (value: string) => {
        const updatedSteps = activityDetails.trainingProgramRecommendedSteps.filter(element => element !== value)
        setActivityDetails({ ...activityDetails, trainingProgramRecommendedSteps: updatedSteps });
    }

    const validateLength = (value: string) => {
        return FieldValidatorService.validateFieldLength(value);
    }

    const handleDeleteActivity = async () => {
        if (activityDetails.trainingProgramId) {
            await TrainingProgramService.deleteTrainingProgram(activityDetails.trainingProgramId)
            history.push("/trainer-dashboard")
        }
    }

    const handleActivity = async () => {
        if (!activityDetails.trainingProgramId) {
            await TrainingProgramService.addTrainingProgram(activityDetails);
            history.push("/trainer-dashboard")
        }
        await TrainingProgramService.updateTrainingProgram(activityDetails);
        history.go(0);
        }

    return (
        hasError ?
            <ErrorMessage responseError={error} />
            : <section className="sb-activity-info-section">
                <div className="sb-activity-header">
                    <div className="sb-activity-admin-btns">
                        <DefaultButton text={intl.formatMessage({ id: "app.activity.actions-delete" })} className="sb-trainer-dashboard-details-btn" onClick={handleDeleteActivity} />
                    </div>
                    <h1 className="sb-activity-details-heading">{activityDetails.trainingProgramName ? activityDetails.trainingProgramName : intl.formatMessage({ id: "app.activity.placeholder-title" })}</h1>
                    <p className="sb-trainer-dashboard-rating">{intl.formatMessage({ id: "app.activity.rating" })}: {activityDetails.trainingProgramRating}</p>
                </div>
                <article className="sb-activity-update-container">
                    <div className="sb-activity-update-info">
                        <h2 className="sb-activity-update-title">{intl.formatMessage({ id: "app.activity.details" })}</h2>
                        <TextField
                            label={intl.formatMessage({ id: "app.activity.name" })}
                            value={activityDetails.trainingProgramName}
                            onChange={(event, newValue) => setActivityDetails({ ...activityDetails, trainingProgramName: newValue! })}
                            validateOnFocusOut
                            validateOnLoad={false}
                            onGetErrorMessage={() => validateLength(activityDetails.trainingProgramName)}
                        />
                        <Dropdown
                            defaultSelectedKey={activityDetails.trainingProgramDifficulty.toLocaleLowerCase()}
                            label={intl.formatMessage({ id: "app.activity.difficulty" })}
                            options={options}
                            onChange={(event, newValue) => setActivityDetails({ ...activityDetails, trainingProgramDifficulty: newValue!.text })}
                        />
                        <TextField
                            label={intl.formatMessage({ id: "app.activity.description" })}
                            value={activityDetails.trainingProgramDescription}
                            onChange={(event, newValue) => setActivityDetails({ ...activityDetails, trainingProgramDescription: newValue! })}
                            multiline rows={3}
                            validateOnFocusOut
                            validateOnLoad={false}
                            onGetErrorMessage={() => validateLength(activityDetails.trainingProgramDescription)}
                        />
                        <TextField
                            label={intl.formatMessage({ id: "app.activity.duration" })}
                            value={activityDetails.trainingProgramDuration}
                            onChange={(event, newValue) => setActivityDetails({ ...activityDetails, trainingProgramDuration: newValue! })}
                            validateOnFocusOut
                            validateOnLoad={false}
                            onGetErrorMessage={() => validateLength(activityDetails.trainingProgramDuration)}
                        />
                        <label className="sb-activity-update-steps-label">{intl.formatMessage({ id: "app.activity.sportCenter" })}</label>
                        <Dropdown
                            className="sb-activity-text-field"
                            defaultSelectedKey={activityDetails.trainingProgramSportCenter?.id}
                            options={centerOptions}
                            onChange={(event: any, newValue: any) => handleChangeSportCenter(newValue!)}
                        />
                        <label className="sb-activity-update-steps-label">{intl.formatMessage({ id: "app.activity.trainer" })}</label>
                        <TextField
                            className="sb-activity-text-field"
                            value={trainerFullName}
                            disabled />
                        <label className="sb-activity-update-steps-label">{intl.formatMessage({ id: "app.activity.recommended-steps" })}</label>
                        <div id="steps">
                            {activityDetails.trainingProgramRecommendedSteps.map((element) => (
                                <div className="sb-activity-update-add-steps">
                                    <TextField
                                        value={element}
                                        className="sb-activity-update-steps-new"
                                        validateOnFocusOut
                                        validateOnLoad={false}
                                        onGetErrorMessage={() => validateLength(element)} />
                                    <FontIcon
                                        className="sb-activity-add-icon"
                                        aria-label="ChartIcon"
                                        iconName="StatusErrorFull"
                                        onClick={() => handleRemoveStep(element)} />
                                </div>
                            ))}
                        </div>
                        <div className="sb-activity-update-add-steps">
                            <TextField
                                value={newStep}
                                className="sb-activity-update-steps-new"
                                placeholder={intl.formatMessage({ id: "app.activity.add-steps" })}
                                onChange={(event) => { setNewStep((event.target as HTMLInputElement).value) }}
                            />
                            <FontIcon
                                className="sb-activity-add-icon"
                                aria-label="ChartIcon"
                                iconName="CircleAdditionSolid"
                                onClick={() => handleAddStep(newStep)} />
                        </div>
                    </div>
                    <DefaultButton text={intl.formatMessage({ id: "app.activity.save-btn" })} className="sb-activity-update-btn" onClick={handleActivity} />
                </article>

            </section>
    )
}

export default Activity;