import { useState, useEffect } from 'react';
import { TextField } from '@fluentui/react/lib/TextField';
import { DefaultButton, PrimaryButton } from '@fluentui/react/lib/Button';
import { SportsCenter } from '../../models/SportsCenters';
import CenterService from '../../services/CenterService';
import { useIntl, FormattedMessage } from 'react-intl';
import FieldValidatorService from '../../services/FieldValidatorService';
import { useHistory } from 'react-router-dom';
import './SportsCenterProfile.scss';
export interface ISportsCenterProfileProps {
    sportsCenter: SportsCenter;
}

const SportsCenterProfile = () => {
    const history = useHistory();
    const intl = useIntl();
    const [centerInfo, setCenterInfo] = useState<SportsCenter>({
        id: 0,
        name: "",
        address: 0,
        addressNavigation: {
            id: 0,
            street: '',
            city: '',
            state: '',
            postalCode: '',
            country: '',
            longitude: 0,
            latitude: 0,

        },
    });

    useEffect(() => {
        const sportCenter: SportsCenter = history.location.state as SportsCenter;
        setCenterInfo(sportCenter);
    }, [history.location.state]);

    const updateCenterProfile = async () => {
        if (formValid) {
            await CenterService.updateCenter(centerInfo.id, centerInfo);
        }
    }

    const deleteCenterProfile = async () => {
        await CenterService.deleteCenterById(centerInfo.id);
    }

    const formValid = centerInfo.name.length && centerInfo.addressNavigation.city.length && centerInfo.addressNavigation.country.length && centerInfo.addressNavigation.postalCode.length && centerInfo.addressNavigation.state.length && centerInfo.addressNavigation.street.length;

    const validateFieldLength = (value: string) => {
        return FieldValidatorService.validateFieldLength(value);
    }

    return (
        <div className="sb-center-profile-outer-container">
            <h2 className="sb-center-title">
                <FormattedMessage
                    id="app.sportsCenterProfile.title"
                    defaultMessage="Edit Center Profile" />
            </h2>
            <div className="sb-center-form">
                <div className="sb-center-form-name">
                    <TextField
                        label={intl.formatMessage({ id: "app.centerProfile.name" })}
                        value={centerInfo.name}
                        placeholder={intl.formatMessage({ id: "app.centerProfile.name" })}
                        onChange={(e, newValue) => setCenterInfo({ ...centerInfo, name: newValue ?? "" })}
                        validateOnFocusOut
                        validateOnLoad={false}
                        onGetErrorMessage={() => validateFieldLength(centerInfo.name)}
                        required />
                    <TextField
                        label={intl.formatMessage({ id: "app.centerProfile.Street" })}
                        placeholder={intl.formatMessage({ id: "app.centerProfile.Street" })}
                        value={centerInfo.addressNavigation.street}
                        onChange={(e, newValue) => setCenterInfo({ ...centerInfo, addressNavigation: { ...centerInfo.addressNavigation, street: newValue ?? "" } })}
                        validateOnFocusOut
                        validateOnLoad={false}
                        onGetErrorMessage={() => validateFieldLength(centerInfo.addressNavigation.street)}
                        required />
                    <TextField
                        label={intl.formatMessage({ id: "app.centerProfile.City" })}
                        value={centerInfo.addressNavigation.city}
                        placeholder={intl.formatMessage({ id: "app.centerProfile.City" })}
                        onChange={(e, newValue) => setCenterInfo({ ...centerInfo, addressNavigation: { ...centerInfo.addressNavigation, city: newValue ?? "" } })}
                        validateOnFocusOut
                        validateOnLoad={false}
                        onGetErrorMessage={() => validateFieldLength(centerInfo.addressNavigation.city)}
                        required />
                    <TextField
                        label={intl.formatMessage({ id: "app.centerProfile.State" })}
                        value={centerInfo.addressNavigation.state}
                        placeholder={intl.formatMessage({ id: "app.centerProfile.State" })}
                        onChange={(e, newValue) => setCenterInfo({ ...centerInfo, addressNavigation: { ...centerInfo.addressNavigation, state: newValue ?? "" } })}
                        validateOnFocusOut
                        validateOnLoad={false}
                        onGetErrorMessage={() => validateFieldLength(centerInfo.addressNavigation.state)}
                        required />
                    <TextField
                        label={intl.formatMessage({ id: "app.centerProfile.PostalCode" })}
                        value={centerInfo.addressNavigation.postalCode}
                        placeholder={intl.formatMessage({ id: "app.centerProfile.PostalCode" })}
                        onChange={(e, newValue) => setCenterInfo({ ...centerInfo, addressNavigation: { ...centerInfo.addressNavigation, postalCode: newValue ?? "" } })}
                        validateOnFocusOut
                        validateOnLoad={false}
                        onGetErrorMessage={() => validateFieldLength(centerInfo.addressNavigation.postalCode)}
                        required />
                    <TextField
                        label={intl.formatMessage({ id: "app.centerProfile.Country" })}
                        value={centerInfo.addressNavigation.country}
                        placeholder={intl.formatMessage({ id: "app.centerProfile.Country" })}
                        onChange={(e, newValue) => setCenterInfo({ ...centerInfo, addressNavigation: { ...centerInfo.addressNavigation, country: newValue ?? "" } })}
                        validateOnFocusOut
                        validateOnLoad={false}
                        onGetErrorMessage={() => validateFieldLength(centerInfo.addressNavigation.country)}
                        required />


                </div>
                <div className="sb-center-buttons">
                    <DefaultButton
                        text={intl.formatMessage({ id: "app.centerProfile.Update" })}
                        disabled={!formValid}
                        onClick={updateCenterProfile}
                    />
                    <PrimaryButton
                        text={intl.formatMessage({ id: "app.centerProfile.Delete" })}
                        disabled={!formValid}
                        onClick={deleteCenterProfile}
                    />
                </div>
            </div>
        </div>
    )
}

export default SportsCenterProfile;