import { DefaultButton } from '@fluentui/react';
import { useIntl } from 'react-intl';
import { useHistory } from 'react-router-dom';
import { TrainingProgram } from '../../models/TrainingProgram';
import TrainingProgramService from '../../services/TrainingProgramService';
import { UserRoleEnum } from '../../models/UserInfo';


type ActivityActionsProps = {
    element: TrainingProgram,
    handleEditMode?: any,
    handleAddMode?: any,
}

const ActivityActions = (props: ActivityActionsProps) => {
    const intl = useIntl();
    const history = useHistory();
    const user = JSON.parse(localStorage.getItem('User')!)

    const handleDeleteActivity = async () => {
        await TrainingProgramService.deleteTrainingProgram(props.element.trainingProgramId);
        history.push("/trainer-dashboard")
    }
    return (
        <div className="sb-activity-header">
            {
                (user.role.id === UserRoleEnum.TRAINER) && <div className="sb-activity-admin-btns">
                    <DefaultButton text={intl.formatMessage({ id: "app.activity.actions-update" })} className="sb-trainer-dashboard-details-btn" onClick={props.handleEditMode} />
                    <DefaultButton text={intl.formatMessage({ id: "app.activity.actions-add" })} className="sb-trainer-dashboard-details-btn" onClick={props.handleAddMode} />
                    <DefaultButton text={intl.formatMessage({ id: "app.activity.actions-delete" })} className="sb-trainer-dashboard-details-btn sb-extended-challenge-buttons-delete" onClick={handleDeleteActivity} />
                </div>
            }
            <h1 className="sb-activity-details-heading">{props.element.trainingProgramName}</h1>
            <p className="sb-trainer-dashboard-rating">{intl.formatMessage({ id: "app.activity.rating" })}: {props.element.trainingProgramRating}</p>
        </div>
    )
}

export default ActivityActions;
