import { Dropdown, FontIcon, IDropdownOption } from '@fluentui/react';
import { useState } from 'react';
import { useIntl } from 'react-intl';
import { TrainingProgram } from '../../models/TrainingProgram';

type ActivityDetailsProps = {
    element: TrainingProgram
}

const ActivityDetails = (props: ActivityDetailsProps) => {

    const intl = useIntl();
    const trainerFullName = `${props.element.trainer.userFirstName} ${props.element.trainer.userLastName}`;
    const centerAddress = `${props.element.trainingProgramSportCenter?.addressNavigation?.street} ${props.element.trainingProgramSportCenter?.addressNavigation?.city} ${props.element.trainingProgramSportCenter?.addressNavigation?.state} ${props.element.trainingProgramSportCenter?.addressNavigation?.postalCode}`;

    const [selectedLocation, setSelectedLocation] = useState<string | number>("at-home");

    const options: IDropdownOption[] = [
        { key: 'at-home', text: intl.formatMessage({ id: "app.activity.location.option1" }) },
        { key: 'at-a-sport-center', text: intl.formatMessage({ id: "app.activity.location.option2" }) }
    ]

    const renderLocationDescription = (location: string | number) => {
        if (selectedLocation === 'at-home') {
            return intl.formatMessage({ id: "app.activity.location.home" });;
        }
        return intl.formatMessage({ id: "app.activity.location.center" });
    }

    return (
        <article className="sb-activity-info-container">
            <h2 className="sb-activity-update-title"> {intl.formatMessage({ id: "app.activity.details" })}</h2>
            <ul className="sb-activity-info-list">
                <li>
                    <span className="sb-activity-details">
                        <FontIcon aria-label="ChartIcon" iconName="FlameSolid" />{' '}
                        {intl.formatMessage({ id: "app.activity.difficulty" })}:
                    </span>{' '}
                    {props.element.trainingProgramDifficulty}
                </li>
                <li>{props.element.trainingProgramDescription}</li>
                <li>
                    <span className="sb-activity-details">
                        <FontIcon aria-label="ChartIcon" iconName="SkypeCircleClock" />{' '}
                        {intl.formatMessage({ id: "app.activity.duration" })}:
                    </span>{' '}
                    {props.element.trainingProgramDuration}
                </li>
                <li>{intl.formatMessage({ id: "app.activity.duration-description" })}</li>
                <li>
                    <span className="sb-activity-details">
                        <FontIcon aria-label="ChartIcon" iconName="MapPinSolid" />{' '}
                        {intl.formatMessage({ id: "app.activity.location" })}:
                    </span>{' '}
                    <Dropdown
                        selectedKey={selectedLocation}
                        options={options}
                        onChange={(event, newValue) => setSelectedLocation(newValue!.key)} />
                </li>
                <li>{renderLocationDescription(selectedLocation)} {(selectedLocation === 'at-home') ? "" : centerAddress}</li>
                <li>
                    <span className="sb-activity-details">
                        <FontIcon aria-label="ChartIcon" iconName="Contact" />{' '}
                        {intl.formatMessage({ id: "app.activity.trainer" })}:
                    </span>{' '}
                    {trainerFullName}
                </li>
                <li>{intl.formatMessage({ id: "app.activity.trainer-description-one" })}{' '}{props.element.trainer.rating} {intl.formatMessage({ id: "app.activity.trainer-description-two" })}</li>
            </ul>
        </article>
    )
}

export default ActivityDetails;