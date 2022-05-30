import React, { useCallback, useEffect, useState } from 'react'
import { FormattedMessage } from 'react-intl';
import Carousel from 'react-elastic-carousel';
import { EventExtended } from '../../models/Event';
import JoinEventService from '../../services/JoinEvent';
import EventCard from '../EventCard/EventCard';
import ActiveEventButtons from '../EventCard/Buttons/ActiveEventButtons';
import JoinSportCenterEventService from '../../services/JoinSportCenterEvent';

const ActiveEvents: React.FC = () => {
    const [trainerEvents, setTrainerEvents] = useState<EventExtended[]>([]);
    const [sportCenterEvents, setSportCenterEvents] = useState<EventExtended[]>([]);

    const getActiveTrainerEvents = useCallback(async () => {
        const response = await JoinEventService.getAllEvents();
        if (!response.hasError) {
            setTrainerEvents(response.data);
        }
    }, [])
    useEffect(() => {

        getActiveTrainerEvents();
    }, [getActiveTrainerEvents])

    const getActiveSportCenterEvents = useCallback(async () => {
        const response = await JoinSportCenterEventService.getAllEvents();
        if (!response.hasError) {
            setSportCenterEvents(response.data);
        }
    }, [])
    useEffect(() => {

        getActiveSportCenterEvents();
    }, [getActiveSportCenterEvents])

    const deleteTrainerEvent = (id: number) => {
        setTrainerEvents(trainerEvents.filter((event) => event.event.id !== id))
    }

    const deleteSportCenterEvent = (id: number) => {
        setSportCenterEvents(sportCenterEvents.filter((event) => event.event.id !== id))
    }

    const breakPoints = [
        { width: 750, itemsToShow: 1, itemsToScroll: 1 },
        { width: 1200, itemsToShow: 2, itemsToScroll: 1 },
    ]

    return (
        <div className='sb-my-challenges-page'>
                <h2 className='sb-profile-title'>
                    <FormattedMessage
                        id='app.event.active.page'
                        defaultMessage='Active Events' />
                </h2>
            <div className='sb-my-challenges-container'>
                <Carousel breakPoints={breakPoints} isRTL={false}>
                    {trainerEvents.map((event: EventExtended) => <EventCard event={event.event}  key={event.eventId}  buttons = {<ActiveEventButtons event={event.event} deleteEvent={deleteTrainerEvent}/>} /> )}
                    {sportCenterEvents.map((event: EventExtended) => <EventCard event={event.event}  key={event.eventId}  buttons = {<ActiveEventButtons event={event.event} deleteEvent={deleteSportCenterEvent}/>} /> )}
                </Carousel>
            </div>
        </div>
    )
}

export default ActiveEvents
