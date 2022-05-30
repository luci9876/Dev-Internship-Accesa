import React from 'react'
import { DefaultButton } from '@fluentui/react';
import JoinEventService from '../../../services/JoinEvent';
import JoinSportCenterEventService from '../../../services/JoinSportCenterEvent';
import { useIntl } from "react-intl";
import {Event} from '../../../models/Event';
import { UserRoleEnum } from '../../../models/UserInfo';

export interface EventButtonProps {
    event: Event;
    deleteEvent: any
}

const CreatedEventButtons: React.FC<EventButtonProps> = ({event, deleteEvent}) => {
    const intl = useIntl();
    const user = JSON.parse(localStorage.getItem('User')!)

    const handleDeletion = async () => {
        if (event.author.role.id === UserRoleEnum.TRAINER) {
            await JoinEventService.deleteEvent(user.id,event.id);
        }
        if (event.author.role.id === UserRoleEnum.ADMIN) {
            await JoinSportCenterEventService.deleteEvent(user.id,event.id);
        }
        deleteEvent(event.id)
    }

    return (
        <div className="sb-extended-challenge-buttons">
                    <DefaultButton
                        className="sb-extended-challenge-buttons-delete"
                        text={intl.formatMessage({ id: "app.event.remove.btn" })}
                        onClick={handleDeletion}
                    />
                </div>
    )
}

export default CreatedEventButtons

