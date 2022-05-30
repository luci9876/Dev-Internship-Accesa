import { Event, EventExtended } from '../../models/Event';
import EventCard from '../EventCard/EventCard'
import { FormattedMessage, useIntl } from 'react-intl';
import { DefaultButton } from '@fluentui/react';
import { useHistory } from 'react-router-dom';
import { useCallback, useEffect, useState } from 'react';
import EventService from '../../services/EventService';
import SportCenterEventService from '../../services/SportCenterEventService';
import EventsPageButtons from '../EventCard/Buttons/EventsPageButtons';
import { DEFAULT_ERROR, ResponseError } from '../../models/Response';
import ErrorMessage from '../ErrorMessage/ErrorMessage';
import Loader from '../Loader/Loader';
import JoinSportCenterEventService from '../../services/JoinSportCenterEvent';

const EventsPage = () => {
    const [trainerEvents, setTrainerEvents] = useState<Event[]>([]);
    const [sportCenterEvents, setSportCenterEvents] = useState<Event[]>([]);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);
    const [isLoading, setIsLoading] = useState(true);
    const intl = useIntl();
    const history = useHistory();
    const [availableEvents, setAvailableEvents] = useState<EventExtended[]>([]);

    const getActiveEvents = useCallback(async () => {
        const response = await JoinSportCenterEventService.getAllEvents();
        if (!response.hasError) {
            setAvailableEvents(response.data);
            setHasError(response.hasError);
            setIsLoading(false);
        }
        else {
            setError({
                errorCode: response.errorCode,
                errorMessage: response.errorMessage
            })
            setHasError(response.hasError);
            setIsLoading(false);
        }
    }, [])

    const getTrainerEvents = useCallback(async () => {
        const response = await EventService.getAllEvents();
        if (!response.hasError) {
            setTrainerEvents(response.data);
            setHasError(response.hasError);
            setIsLoading(false);
            return;
        }

        setError({
            errorCode: response.errorCode,
            errorMessage: response.errorMessage
        })
        setHasError(response.hasError);
        setIsLoading(false);
    }, []);

    const getSportCenterEvents = useCallback(async () => {
        const response = await SportCenterEventService.getAllEvents();
        if (!response.hasError) {
            setSportCenterEvents(response.data);
            setHasError(response.hasError);
            setIsLoading(false);
            return;
        }

        setError({
            errorCode: response.errorCode,
            errorMessage: response.errorMessage
        })
        setHasError(response.hasError);
        setIsLoading(false);
    }, []);

    useEffect(() => {
        getTrainerEvents();
        getActiveEvents();
        getSportCenterEvents();
    }, [getTrainerEvents, getActiveEvents, getSportCenterEvents]);

    return (
        isLoading ?
            <Loader /> :
            hasError ?
                <ErrorMessage responseError={error} />
                :
                <div className='sb-event-page-full'>
                <div className='sb-challenge-page'>
                    <div className='sb-profile-title'>
                        <h2>
                            <FormattedMessage
                                id='app.event.page.title'
                                defaultMessage='Available Events' />
                        </h2>
                        <DefaultButton
                            text={intl.formatMessage({ id: 'app.event.my-events.btn' })}
                            onClick={() => history.push('/my-events')} />
                    </div>
                    {trainerEvents.map((event: Event) => <EventCard event={event} key={event.id} buttons={<EventsPageButtons event={event} availableEvents={availableEvents} />} />)}
                    {sportCenterEvents.map((event: Event) => <EventCard event={event} key={event.id} buttons={<EventsPageButtons event={event} availableEvents={availableEvents} />} />)}
                </div>
                </div>
    )
}

export default EventsPage
