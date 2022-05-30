import React from 'react'
import { DefaultButton } from '@fluentui/react';
import { useHistory } from 'react-router-dom';
import EventService from '../../../services/EventService';
import SportCenterEventService from '../../../services/SportCenterEventService';
import { useIntl } from "react-intl";
import {Event} from '../../../models/Event';
import { UserRoleEnum } from '../../../models/UserInfo';

export interface EventButtonProps {
    event: Event;
    deleteEvent: any
}

const CreatedEventButtons: React.FC<EventButtonProps> = ({event, deleteEvent}) => {
    const intl = useIntl();
    const history = useHistory();

    const handleDeletion = async () => {
        if (event.author.role.id === UserRoleEnum.TRAINER) {
            await EventService.deleteEvent(event.id);
        }
        if (event.author.role.id === UserRoleEnum.ADMIN) {
            await SportCenterEventService.deleteEvent(event.id);
        }
        deleteEvent(event.id)
    }

    return (
        <div className="sb-extended-challenge-buttons">
                    <DefaultButton
                        text={intl.formatMessage({ id: "app.event.editEvent" })}
                        onClick={() => history.push(`/edit-event/${event.id}`)} />
                    <DefaultButton
                        className="sb-extended-challenge-buttons-delete"
                        text={intl.formatMessage({ id: "app.event.deleteEvent" })}
                        onClick={handleDeletion}
                    />
                </div>
    )
}

export default CreatedEventButtons

