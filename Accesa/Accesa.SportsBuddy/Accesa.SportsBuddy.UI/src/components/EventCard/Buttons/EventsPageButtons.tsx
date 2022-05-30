import React, { useEffect, useState } from 'react'
import { DefaultButton } from '@fluentui/react';
import { useIntl } from "react-intl";
import { Event, EventExtended, JoinEvent } from '../../../models/Event';
import JoinEventService from '../../../services/JoinEvent';
import JoinSportCenterEventService from '../../../services/JoinSportCenterEvent';
import { UserRoleEnum } from '../../../models/UserInfo';
import SuccessMessage from '../../SuccessMessage/SuccessMessage';
import '../EventCard.scss';

export interface EventButtonProps {
    event: Event;
    availableEvents: EventExtended[];
}

const EventsPageButtons: React.FC<EventButtonProps> = ({ event, availableEvents }) => {
    const intl = useIntl();
    const user = JSON.parse(localStorage.getItem('User')!)
    const [shouldShowSuccessMessage, setShouldShowSuccessMessage] = useState(false);

    const[userEvents, setUserEvents]=useState<EventExtended[]>([])

    useEffect (()=>{
        setUserEvents(availableEvents);
    },[availableEvents])

    const joinEvent: JoinEvent = {
        eventId: event.id,
        userId: user.id
    }
    const setMessage = () => {
        setShouldShowSuccessMessage(true);
        setTimeout(() => {
            setShouldShowSuccessMessage(false);
        }, 2000);
    }

    const isAvailable = () => {
        return userEvents.filter((e: EventExtended) => e.eventId === event.id).length>0;
    }

    const addEvent = async () => {
        if (event.author.role.id === UserRoleEnum.TRAINER) {
            await JoinEventService.addEvent(joinEvent);
            setMessage();
        }
        if (event.author.role.id === UserRoleEnum.ADMIN) {
            await JoinSportCenterEventService.addEvent(joinEvent);
            setMessage();
        }
    }

    return (
        <div>
            <DefaultButton
                text={intl.formatMessage({ id: "app.event.join.btn" })}
                onClick={addEvent}
                disabled={isAvailable()}
            />
            <SuccessMessage shouldShowSuccessMessage={shouldShowSuccessMessage} id={"app.event.success.join"} />
        </div>
    )
}

export default EventsPageButtons

