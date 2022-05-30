import React, { useCallback, useEffect, useState } from 'react'
import { FormattedMessage, useIntl } from 'react-intl';
import Carousel from 'react-elastic-carousel';
import { Event } from '../../models/Event';
import EventService from '../../services/EventService';
import SportCenterEventService from '../../services/SportCenterEventService';
import EventCard from '../EventCard/EventCard';
import CreatedEventButtons from '../EventCard/Buttons/CreatedEventButtons';
import { DefaultButton } from '@fluentui/react';
import { useHistory } from 'react-router-dom';
import { UserRoleEnum } from '../../models/UserInfo';


const CreatedEvents: React.FC = () => {
    const [events, setEvents] = useState<Event[]>([]);
    const intl = useIntl();
    const history = useHistory();
    const user = JSON.parse(localStorage.getItem('User')!)

    const getCreatedEvents = useCallback(async () => {
        if (user.role.id === UserRoleEnum.TRAINER) {
            const response = await EventService.getEventsByAuthor(user.id);
            if (!response.hasError) {
                setEvents(response.data);
            }
        }
        if (user.role.id === UserRoleEnum.ADMIN) {
            const response = await SportCenterEventService.getEventsByAuthor(user.id);
            if (!response.hasError) {
                setEvents(response.data);
            }
        }
    }, [])

    useEffect(() => {

        getCreatedEvents();
    }, [getCreatedEvents])

    const deleteEvent = (id: number) => {
        setEvents(events.filter((event) => event.id !== id))
    }

    const breakPoints = [
        { width: 750, itemsToShow: 1, itemsToScroll: 1 },
        { width: 1200, itemsToShow: 2, itemsToScroll: 1 },
    ]

    return (
        <div className='sb-my-challenges-page'>
            <div className='sb-profile-title'>
                <h2 >
                    <FormattedMessage
                        id='app.event.create.page'
                        defaultMessage='Created Events' />
                </h2>
                <div>
                    <DefaultButton
                        className="sb-my-chellenges-create-btn"
                        text={intl.formatMessage({ id: 'app.event.create.title' })}
                        onClick={() => history.push('/create-event')}
                    />
                    <DefaultButton
                        text={intl.formatMessage({ id: 'app.event.all.events.btn' })}
                        onClick={() => history.push('/events')}
                    />
                </div>
            </div>
            <div className='sb-my-challenges-container'>
                <Carousel breakPoints={breakPoints} isRTL={false}>
                    {events.map((event: Event) => <EventCard event={event} key={event.id} buttons={<CreatedEventButtons event={event} deleteEvent={deleteEvent} />} />)}
                </Carousel>
            </div>
        </div>
    )
}

export default CreatedEvents
