import React, { useCallback, useEffect, useState } from 'react'
import { TextField } from '@fluentui/react/lib/TextField';
import { DatePicker, Dropdown, IDropdownOption } from '@fluentui/react';
import { DefaultButton } from '@fluentui/react/lib/Button';
import { UserProfileProps } from './UserProfile';
import { Trainee } from '../../models/Trainee';
import { UserRoleEnum, GenderEnum } from '../../models/UserInfo';
import TraineeService from '../../services/TraineeService';
import { useIntl, FormattedMessage } from 'react-intl';
import ErrorMessage from '../ErrorMessage/ErrorMessage';
import { DEFAULT_ERROR, ResponseError } from '../../models/Response';
import FieldValidatorService from '../../services/FieldValidatorService';
import TrainerService from '../../services/TrainerService';
import { useHistory } from 'react-router-dom';
import Loader from '../Loader/Loader';

const TraineeProfile: React.FC<UserProfileProps<Trainee>> = ({ user }) => {
    const [userInfo, setUserInfo] = useState<Trainee>(user);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);
    const[isLoading, setIsLoading] = useState<boolean>(false)
    const intl = useIntl();
    const history = useHistory();

    const updateProfileInfo = async () => {
        if (formValid) {
            setIsLoading(true);
            await TraineeService.updateTrainee(userInfo);
            setIsLoading(false);
            history.go(0);
            localStorage.setItem('User', JSON.stringify(userInfo));
        }
    };

    const upgradeToTrainer = async () => {
        userInfo.role = {
            id: UserRoleEnum.TRAINER,
            name: 'Trainer'
        };
        if (formValid) {
            await TraineeService.updateTrainee(userInfo);
            await TrainerService.addTrainer({ ...userInfo, trainerId: 0, rating: 0, isAvailable: false })
            localStorage.removeItem('User')
            localStorage.removeItem('token')
            localStorage.setItem('accountExists', JSON.stringify(false));
            history.push('/login');
        }
    };

    const formValid = userInfo.firstName.length && userInfo.lastName.length && userInfo.email.length && userInfo.birthDate && userInfo.phoneNumber.length;

    const validateLength = (value: string) => {
        return FieldValidatorService.validateFieldLength(value);
    }

    const validateEmail = (value: string) => {
        return FieldValidatorService.validateEmail(value);
    }

    const validatePhoneNumber = (value: string) => {
        return FieldValidatorService.validatePhoneNumber(value);
    }

    const options: IDropdownOption[] = [
        { key: GenderEnum.MALE, text: 'M' },
        { key: GenderEnum.FEMALE, text: 'F' },
    ];

    return (
        isLoading ?
        <Loader /> :
            hasError ?
                <ErrorMessage responseError={error} />
                : <div className="sb-user-profile-full">
                 <div className="sb-user-profile">
                    <div className="sb-profile-title">
                        <h2>
                            <FormattedMessage
                                id="app.userProfile.title"
                                defaultMessage="Edit Profile" />
                        </h2>
                        <div>
                            <span>{userInfo.role.name}</span>
                            <img src={'/default.png'} alt="name" />
                        </div>
                    </div>
                    <section className="sb-profile-short">
                        <img src={'/default.png'} alt="name" />
                    </section>
                    <form className="sb-user-form">
                        <div className="sb-user-form-name">
                            <TextField
                                label={intl.formatMessage({ id: "app.userProfile.firstName" })}
                                value={userInfo.firstName}
                                placeholder={intl.formatMessage({ id: "app.userProfile.firstName" })}
                                onChange={(e, newValue) => setUserInfo({ ...userInfo, firstName: newValue ?? '' })}
                                validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(userInfo.firstName)}
                                required />
                            <TextField
                                label={intl.formatMessage({ id: "app.userProfile.lastName" })}
                                placeholder={intl.formatMessage({ id: "app.userProfile.lastName" })}
                                value={userInfo.lastName}
                                onChange={(e, newValue) => setUserInfo({ ...userInfo, lastName: newValue ?? '' })}
                                validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(userInfo.lastName)}
                                required />
                        </div>
                        <TextField
                            label={intl.formatMessage({ id: "app.userProfile.Email" })}
                            type="email"
                            placeholder={intl.formatMessage({ id: "app.userProfile.Email" })}
                            value={userInfo.email}
                            onChange={(e, newValue) => setUserInfo({ ...userInfo, email: newValue ?? '' })}
                            validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateEmail(userInfo.email)}
                            required />
                        <DatePicker
                            label={intl.formatMessage({ id: "app.userProfile.birthDate" })}
                            value={new Date(userInfo.birthDate)}
                            onSelectDate={(newDate: Date | null | undefined) => { if (newDate) { setUserInfo({ ...userInfo, birthDate: newDate }) } }} />
                        <Dropdown
                            placeholder={userInfo.gender}
                            label={intl.formatMessage({ id: "app.userProfile.Gender" })}
                            onChange={(e, option) => setUserInfo({ ...userInfo, gender: (option?.key as GenderEnum) })}
                            options={options}
                        />
                        <TextField
                            label={intl.formatMessage({ id: "app.userProfile.phoneNumber" })}
                            placeholder={intl.formatMessage({ id: "app.userProfile.phoneNumber" })}
                            value={userInfo.phoneNumber}
                            onChange={(e, newValue) => setUserInfo({ ...userInfo, phoneNumber: newValue ?? '' })}
                            validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validatePhoneNumber(userInfo.phoneNumber)}
                            required />
                        <div>
                            <TextField
                                label={intl.formatMessage({ id: "app.userProfile.street" })}
                                placeholder={intl.formatMessage({ id: "app.userProfile.street" })}
                                value={userInfo.addressNavigation!.street}
                                onChange={(e, newValue) => setUserInfo({ ...userInfo, addressNavigation: { ...userInfo.addressNavigation!, street: newValue ?? "" } })}
                                validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(userInfo.addressNavigation!.street)}
                                required />
                            <div className="sb-user-form-name">
                                <TextField
                                    label={intl.formatMessage({ id: "app.userProfile.postalCode" })}
                                    placeholder={intl.formatMessage({ id: "app.userProfile.postalCode" })}
                                    value={userInfo.addressNavigation!.postalCode}
                                    onChange={(e, newValue) => setUserInfo({ ...userInfo, addressNavigation: { ...userInfo.addressNavigation!, postalCode: newValue ?? "" } })}
                                    validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(userInfo.phoneNumber)}
                                    required />
                                <TextField
                                    label={intl.formatMessage({ id: "app.userProfile.city" })}
                                    placeholder={intl.formatMessage({ id: "app.userProfile.city" })}
                                    value={userInfo.addressNavigation!.city}
                                    onChange={(e, newValue) => setUserInfo({ ...userInfo, addressNavigation: { ...userInfo.addressNavigation!, city: newValue ?? "" } })}
                                    validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(userInfo.phoneNumber)}
                                    required />
                            </div>
                            <div className="sb-user-form-name">
                                <TextField
                                    label={intl.formatMessage({ id: "app.userProfile.state" })}
                                    placeholder={intl.formatMessage({ id: "app.userProfile.state" })}
                                    value={userInfo.addressNavigation!.state}
                                    onChange={(e, newValue) => setUserInfo({ ...userInfo, addressNavigation: { ...userInfo.addressNavigation!, state: newValue ?? "" } })}
                                    validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(userInfo.phoneNumber)}
                                    required />
                                <TextField
                                    label={intl.formatMessage({ id: "app.userProfile.country" })}
                                    placeholder={intl.formatMessage({ id: "app.userProfile.country" })}
                                    value={userInfo.addressNavigation!.country}
                                    onChange={(e, newValue) => setUserInfo({ ...userInfo, addressNavigation: { ...userInfo.addressNavigation!, country: newValue ?? "" } })}
                                    validateOnFocusOut validateOnLoad={false} onGetErrorMessage={() => validateLength(userInfo.phoneNumber)}
                                    required />
                            </div>
                        </div>
                        <div className="sb-profile-buttons">
                            <DefaultButton
                                text={intl.formatMessage({ id: "app.userProfile.btn.Update" })}
                                disabled={!formValid}
                                onClick={updateProfileInfo} />
                            <DefaultButton
                                text={intl.formatMessage({ id: "app.userProfile.btn.Upgrade" })}
                                disabled={!formValid}
                                onClick={upgradeToTrainer}
                            />
                        </div>
                    </form>
                </div>
            </div>
    )
}

export default TraineeProfile
