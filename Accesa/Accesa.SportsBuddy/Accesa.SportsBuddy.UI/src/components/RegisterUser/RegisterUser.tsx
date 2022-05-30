import { TextField } from '@fluentui/react/lib/TextField';
import { PrimaryButton } from '@fluentui/react/lib/Button';
import { Label } from '@fluentui/react/lib/Label';
import { DayOfWeek, DatePicker, defaultDatePickerStrings } from '@fluentui/react';
import './RegisterUser.scss';
import { useState } from 'react';
import { Trainee } from '../../models/Trainee';
import { GenderEnum, UserRoleEnum } from '../../models/UserInfo';
import AuthService from '../../services/AuthService';
import { FormattedMessage, useIntl } from 'react-intl';
import FieldValidatorService from '../../services/FieldValidatorService';
import moment from 'moment';
import { useHistory } from 'react-router-dom';


const RegisterUser = () => {

    const intl = useIntl()
    let history = useHistory();

    const [user, setUser] = useState<Trainee>({
        firstName: "",
        lastName: "",
        email: "",
        password: "",
        addressNavigation: {
            street: '',
            city: '',
            state: '',
            postalCode: '',
            country: '',
        },
        gender: GenderEnum.FEMALE,
        birthDate: new Date(),
        createdAt: new Date(),
        phoneNumber: "",
        role: {
            id: UserRoleEnum.TRAINEE,
            name: ""
        }
    });

    const formValid = user.firstName.length && user.lastName.length && user.email.length && user.password!.length && user.birthDate && user.phoneNumber.length;

    const validateLength = (value: string) => {
        return FieldValidatorService.validateFieldLength(value);
    }

    const validateEmail = (value: string) => {
        return FieldValidatorService.validateEmail(value);
    }

    const validatePhoneNumber = (value: string) => {
        return FieldValidatorService.validatePhoneNumber(value);
    }

    const dateFormat = intl.formatMessage({ id: "app.date-format" });

    const handleRegister = async () => {
        if (formValid) {
            await AuthService.registerUser(user);
            history.push('/login');
        }
    }

    return (
        <div className="sb-register-full">
        <div className="sb-register">
            <div className="sb-register-container">
                <h1 className="sb-register-heading">{intl.formatMessage({ id: "app.register.heading" })}</h1>
                <div className="sb-register-inputs-container">

                    <TextField
                        placeholder={intl.formatMessage({ id: "app.register.firstNamePlaceholder" })}
                        label={intl.formatMessage({ id: "app.register.firstName" })}
                        className="sb-register-inputs"
                        value={user.firstName}
                        onChange={(event, newValue) => setUser({ ...user, firstName: newValue! })}
                        validateOnFocusOut
                        validateOnLoad={false}
                        onGetErrorMessage={() => validateLength(user.firstName)}
                        required />
                    <TextField
                        placeholder={intl.formatMessage({ id: "app.register.LastNamePlaceholder" })}
                        label={intl.formatMessage({ id: "app.register.LastName" })}
                        className="sb-register-inputs"
                        value={user.lastName}
                        onChange={(event, newValue) => setUser({ ...user, lastName: newValue! })}
                        validateOnFocusOut
                        validateOnLoad={false}
                        onGetErrorMessage={() => validateLength(user.lastName)}
                        required />
                    <TextField
                        placeholder={intl.formatMessage({ id: "app.register.EmailPlaceholder" })}
                        label={intl.formatMessage({ id: "app.register.Email" })}
                        className="sb-register-inputs"
                        value={user.email}
                        onChange={(event, newValue) => setUser({ ...user, email: newValue! })}
                        validateOnFocusOut
                        validateOnLoad={false}
                        onGetErrorMessage={() => validateEmail(user.email)}
                        required />
                    <TextField
                        placeholder={intl.formatMessage({ id: "app.register.PasswordPlaceholder" })}
                        label={intl.formatMessage({ id: "app.register.Password" })}
                        type="password"
                        canRevealPassword
                        revealPasswordAriaLabel="Show password"
                        className="sb-register-inputs"
                        value={user.password}
                        onChange={(event, newValue) => setUser({ ...user, password: newValue! })}
                        validateOnFocusOut
                        validateOnLoad={false}
                        onGetErrorMessage={() => validateLength(user.password!)}
                        required />
                    <Label
                        className="sb-register-date-label"
                        required>
                        {intl.formatMessage({ id: "app.register.birthDate" })}
                    </Label>
                    <DatePicker
                        firstDayOfWeek={DayOfWeek.Sunday}
                        placeholder={intl.formatMessage({ id: "app.register.birthDatePlaceholder" })}
                        ariaLabel="Select a date"
                        strings={defaultDatePickerStrings}
                        className="sb-register-date"
                        value={user.birthDate}
                        formatDate={(date?: Date): string => {
                            return moment(date).format(dateFormat);
                        }}
                        onSelectDate={(newValue) => setUser({ ...user, birthDate: newValue! })}
                    />
                    <TextField
                        placeholder={intl.formatMessage({ id: "app.register.PhoneNumberPlaceholder" })}
                        label={intl.formatMessage({ id: "app.register.PhoneNumber" })}
                        className="sb-register-inputs"
                        value={user.phoneNumber}
                        onChange={(event, newValue) => setUser({ ...user, phoneNumber: newValue! })}
                        validateOnFocusOut
                        validateOnLoad={false}
                        onGetErrorMessage={() => validatePhoneNumber(user.phoneNumber)}
                        required />
                    <p
                        onClick={() => {
                            history.push("/login")
                        }}
                        className="sb-login-option">
                        <FormattedMessage
                            id="app.userRegister.loginText"
                            defaultMessage="Already have an account? Login here."
                        ></FormattedMessage>
                    </p>
                </div>
                <PrimaryButton
                    disabled={!formValid}
                    text={intl.formatMessage({ id: "app.register.btn" })}
                    className="sb-register-btn"
                    onClick={handleRegister}
                />
            </div>
        </div>
      </div>
    )
}


export default RegisterUser;