import './EventCard.scss';
import moment from "moment";
import { FormattedMessage } from "react-intl";
import { Event } from "../../models/Event";

export interface EventProps {
    event: Event,
    buttons: React.ReactNode
}

const EventCard: React.FC<EventProps> = ({ event, buttons }) => {

    return (
        <div className='sb-event-card'>
            <h2>{event.title}</h2>
            <div className='sb-event-content'>
                <div className='sb-event-description'>
                    <p className="sb-event-card-text-limiter"><strong>
                        <FormattedMessage
                            id="app.createChallenge.challenge.description"
                            defaultMessage="Description" />
                    </strong>: {event.description}</p>
                    <p>
                        <strong>
                            <FormattedMessage
                                id="app.createChallenge.challenge.outcome"
                                defaultMessage="Goal" />
                        </strong>: {event.goal}</p>
                    <p><strong>
                        <FormattedMessage
                            id="app.event.card.startDate"
                            defaultMessage="Starting at:" />
                    </strong>: {moment(`${event.startDate}`).format('HH:MM DD.MM.YYYY')}</p>
                    <p><strong>
                        <FormattedMessage
                            id="app.event.card.duration"
                            defaultMessage="Duration" />
                    </strong>: {event.duration}</p>
                </div>
                <div className="sb-event-address">
                    <h3><FormattedMessage
                        id="app.event.card.address"
                        defaultMessage="Event address" /></h3>
                    <p><strong>
                        <FormattedMessage
                            id="app.userProfile.street"
                            defaultMessage="Street" />
                    </strong>: {event.address.street}</p>
                    <p><strong>
                        <FormattedMessage
                            id="app.userProfile.postalCode"
                            defaultMessage="Postal code" />
                    </strong>: {event.address.postalCode}</p>
                    <p><strong>
                        <FormattedMessage
                            id="app.userProfile.city"
                            defaultMessage="City" />
                    </strong>: {event.address.city}</p>
                    <p><strong>
                        <FormattedMessage
                            id="app.userProfile.state"
                            defaultMessage="State" />
                    </strong>: {event.address.state}</p>
                    <p><strong>
                        <FormattedMessage
                            id="app.userProfile.country"
                            defaultMessage="Country" />
                    </strong>: {event.address.country}</p>
                </div>
            </div>
            {buttons}
        </div>
    )
}

export default EventCard
