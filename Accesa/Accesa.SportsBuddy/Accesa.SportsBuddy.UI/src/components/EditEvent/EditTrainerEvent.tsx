
import { useIntl, FormattedMessage } from 'react-intl';
import { DatePicker, DefaultButton, TextField } from '@fluentui/react';
import { Event, DEFAULT_EVENT } from '../../models/Event';
import { useCallback, useEffect, useState } from 'react';
import FieldValidatorService from '../../services/FieldValidatorService';
import { useHistory } from 'react-router-dom';
import EventService from '../../services/EventService';
import SportCenterEventService from '../../services/SportCenterEventService';
import { UserRoleEnum } from '../../models/UserInfo';

const EditTrainerEvent = () => {
    const intl = useIntl();
    const [eventInfo, setEventInfo] = useState<Event>(DEFAULT_EVENT);
    const history = useHistory();
    const user = JSON.parse(localStorage.getItem('User')!)

    const validateLength = (value: string) => {
        return FieldValidatorService.validateFieldLength(value);
    }

    const formValid = eventInfo.title && eventInfo.description && eventInfo.duration && eventInfo.goal && eventInfo.address.city && eventInfo.address.country && eventInfo.address.postalCode && eventInfo.address.state && eventInfo.address.street;

    let urlElements = window.location.href.split("/");
    let eventId = parseInt(urlElements[urlElements.length - 1], 10);

    const getEvent = useCallback(async () => {
        if (user.role.id === UserRoleEnum.TRAINER) {
            const response = await EventService.getEventById(eventId);
            if (!response.hasError) {
                setEventInfo(response.data);
            }
        }
        if (user.role.id === UserRoleEnum.ADMIN) {
            const response = await SportCenterEventService.getEventById(eventId);
            if (!response.hasError) {
                setEventInfo(response.data);
            }
        }
    }, [eventId])
    
    useEffect(() => {
        getEvent();
    }, [getEvent])

    const handleUpdate = async () => {
        if (!formValid) {
            return;
        }
        if (user.role.id === UserRoleEnum.TRAINER) {
            await EventService.updateEvent(eventInfo);
        }
        if (user.role.id === UserRoleEnum.ADMIN) {
            await SportCenterEventService.updateEvent(eventInfo);
        }
    }

    return (
        <div className='sb-create-challenge-page'>
            <div className="sb-challenge-title">
                <h2>
                    <FormattedMessage
                        id="app.event.edit.title"
                        defaultMessage="Edit Event" />
                </h2>
                <DefaultButton
                    text={intl.formatMessage({ id: 'app.event.myEvents.btn' })}
                    onClick={() => history.push('/my-events')} />
            </div>
            <form className="sb-user-form">
                <TextField
                    label={intl.formatMessage({ id: "app.createChallenge.challenge.title" })}
                    value={eventInfo.title}
                    placeholder={intl.formatMessage({ id: "app.createChallenge.challenge.title" })}
                    onChange={(e, newValue) => setEventInfo({ ...eventInfo, title: newValue ?? '' })}
                    validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(eventInfo.title)}
                    required />
                <TextField
                    label={intl.formatMessage({ id: "app.createChallenge.challenge.description" })}
                    value={eventInfo.description}
                    multiline={true}
                    placeholder={intl.formatMessage({ id: "app.createChallenge.challenge.description" })}
                    onChange={(e, newValue) => setEventInfo({ ...eventInfo, description: newValue ?? '' })}
                    validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(eventInfo.description)}
                    required />
                <TextField
                    label={intl.formatMessage({ id: "app.createChallenge.challenge.outcome" })}
                    value={eventInfo.goal}
                    placeholder={intl.formatMessage({ id: "app.createChallenge.challenge.outcome" })}
                    onChange={(e, newValue) => setEventInfo({ ...eventInfo, goal: newValue ?? '' })}
                    validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(eventInfo.goal)}
                    required />
                <DatePicker
                    label={intl.formatMessage({ id: "app.event.card.startDate" })}
                    value={new Date(eventInfo.startDate)}
                    onSelectDate={(newDate: Date | null | undefined) => { if (newDate) { setEventInfo({ ...eventInfo, startDate: newDate }) } }} />
                <TextField
                    label={intl.formatMessage({ id: "app.event.card.duration" })}
                    value={eventInfo.duration}
                    placeholder={intl.formatMessage({ id: "app.event.card.duration" })}
                    onChange={(e, newValue) => setEventInfo({ ...eventInfo, duration: newValue ?? '' })}
                    validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(eventInfo.duration)}
                    required />
                <div>
                    <TextField
                        label={intl.formatMessage({ id: "app.userProfile.street" })}
                        placeholder={intl.formatMessage({ id: "app.userProfile.street" })}
                        value={eventInfo.address!.street}
                        onChange={(e, newValue) => setEventInfo({ ...eventInfo, address: { ...eventInfo.address!, street: newValue ?? "" } })}
                        validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(eventInfo.address!.street)}
                        required />
                    <div className="sb-user-form-name">
                        <TextField
                            label={intl.formatMessage({ id: "app.userProfile.postalCode" })}
                            placeholder={intl.formatMessage({ id: "app.userProfile.postalCode" })}
                            value={eventInfo.address!.postalCode}
                            onChange={(e, newValue) => setEventInfo({ ...eventInfo, address: { ...eventInfo.address!, postalCode: newValue ?? "" } })}
                            validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(eventInfo.address!.postalCode)}
                            required />
                        <TextField
                            label={intl.formatMessage({ id: "app.userProfile.city" })}
                            placeholder={intl.formatMessage({ id: "app.userProfile.city" })}
                            value={eventInfo.address!.city}
                            onChange={(e, newValue) => setEventInfo({ ...eventInfo, address: { ...eventInfo.address!, city: newValue ?? "" } })}
                            validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(eventInfo.address!.city)}
                            required />
                    </div>
                    <div className="sb-user-form-name">
                        <TextField
                            label={intl.formatMessage({ id: "app.userProfile.state" })}
                            placeholder={intl.formatMessage({ id: "app.userProfile.state" })}
                            value={eventInfo.address!.state}
                            onChange={(e, newValue) => setEventInfo({ ...eventInfo, address: { ...eventInfo.address!, state: newValue ?? "" } })}
                            validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(eventInfo.address!.state)}
                            required />
                        <TextField
                            label={intl.formatMessage({ id: "app.userProfile.country" })}
                            placeholder={intl.formatMessage({ id: "app.userProfile.country" })}
                            value={eventInfo.address!.country}
                            onChange={(e, newValue) => setEventInfo({ ...eventInfo, address: { ...eventInfo.address!, country: newValue ?? "" } })}
                            validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(eventInfo.address!.country)}
                            required />
                    </div>
                    <div className="sb-profile-buttons">
                        <DefaultButton
                            text={intl.formatMessage({ id: "app.challenges.btn.createChallenge" })}
                            disabled={!formValid}
                            onClick={handleUpdate}
                        />
                    </div>
                </div>
            </form>
        </div>
    )
}


export default EditTrainerEvent
