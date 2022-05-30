import { FontIcon } from '@fluentui/react/lib/Icon';
import { DefaultButton } from '@fluentui/react/lib/Button';
import { Link } from "react-router-dom";
import { useIntl } from 'react-intl';
import { TrainingProgram } from '../../models/TrainingProgram';

type CardProps = {
    element: TrainingProgram
    isUserMainPage?: boolean
}

const ActivityCard = (props: CardProps) => {
    const intl = useIntl();

    const trainerFullName = `${props.element.trainer.userFirstName} ${props.element.trainer.userLastName}`;
    const isLogged = JSON.parse(localStorage.getItem("accountExists")!);

    return (
        <article key={props.element.trainingProgramId} className="sb-cards">
            <div className="sb-card-heading">
                <h2 className="sb-activity-heading-title" >{props.element.trainingProgramName}</h2>
                <p>{intl.formatMessage({ id: "app.activityCard.rating" })}: {props.element.trainingProgramRating}</p>
            </div>
            <div className="sb-info">
                <ul className="sb-activity-card-info">
                    <li><span className="sb-description"><FontIcon aria-label="ChartIcon" iconName="PageListSolid" />  {intl.formatMessage({ id: "app.activityCard.description" })}:</span><span className="sb-activity-card-description-text"> {props.element.trainingProgramDescription}</span></li>
                    <li><span className="sb-description"><FontIcon aria-label="ChartIcon" iconName="FlameSolid" /> {intl.formatMessage({ id: "app.activityCard.difficulty" })}:</span> {props.element.trainingProgramDifficulty}</li>
                    <li><span className="sb-description"><FontIcon aria-label="ChartIcon" iconName="SkypeCircleClock" />  {intl.formatMessage({ id: "app.activityCard.duration" })}:</span> {props.element.trainingProgramDuration}</li>
                    <li><span className="sb-description"><FontIcon aria-label="ChartIcon" iconName="Contact" />  {intl.formatMessage({ id: "app.activityCard.trainer" })}:</span> {trainerFullName}</li>
                </ul>
                {
                    isLogged
                        ?
                        <Link to={`/activity-page/${props.element.trainingProgramId}`}> <DefaultButton text={intl.formatMessage({ id: "app.activityCard.btn.seeDetails" })} className="sb-btn" /></Link>
                        :
                        <DefaultButton text={intl.formatMessage({ id: "app.activityCard.btn.seeDetails" })} className="sb-btn-main-page__details" disabled={!props.isUserMainPage} />
                }
            </div>
        </article>
    )
}


export default ActivityCard;