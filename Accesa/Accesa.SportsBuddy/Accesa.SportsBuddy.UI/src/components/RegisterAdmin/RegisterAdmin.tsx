import { TextField } from '@fluentui/react/lib/TextField';
import { PrimaryButton } from '@fluentui/react/lib/Button';
import { DayOfWeek, DatePicker, defaultDatePickerStrings, Label } from '@fluentui/react';
import './RegisterAdmin.scss';
import { useState } from 'react';
import AuthService from '../../services/AuthService';
import { Admin, DEFAULT_ADMIN } from '../../models/Admin';
import { useHistory } from 'react-router-dom'
import { useIntl, FormattedMessage } from 'react-intl';
import FieldValidatorService from '../../services/FieldValidatorService';
import moment from 'moment';

const RegisterAdmin = () => {

    let history = useHistory();
    const intl = useIntl();

    const [registerInfo, setRegisterInfo] = useState<Admin>(DEFAULT_ADMIN);

    // const [firstName, setFirstName] = useState("");
    // const [lastName, setLastName] = useState("");
    // const [email, setEmail] = useState("");
    // const [password, setPassword] = useState("");
    // const [birthDate, setBirthDate] = useState(new Date());
    // const [phoneNumber, setPhoneNumber] = useState("");
    // const [sportsCenter, setSportsCenter] = useState("");

    // const registerInfo: Admin = {
    //     firstName: registerInfo.firstName,
    //     lastName: registerInfo.lastName,
    //     email: registerInfo.email,
    //     password: registerInfo.password,
    //     birthDate: registerInfo.birthDate,
    //     phoneNumber: registerInfo.phoneNumber,
    //     sportsCenters: [{
    //         name: sportsCenter,
    //     }],
    // }

    const formValid = registerInfo.name.length && registerInfo.email.length && registerInfo.password.length && registerInfo.birthDate && registerInfo.phoneNumber.length;

    const dateFormat = intl.formatMessage({ id: "app.date-format" });

    const validateFieldLength = (value: string) => {
        return FieldValidatorService.validateFieldLength(value);
    }

    const validateEmail = (value: string) => {
        return FieldValidatorService.validateEmail(value);
    }

    const validatePhoneNumber = (value: string) => {
        return FieldValidatorService.validatePhoneNumber(value);
    }

    const handleRegister = async () => {
        if (formValid) {
            //here should also redirect to a page on which the Admin can choose his Sport Centers 
            await AuthService.registerAdmin(registerInfo);
        }

    }

    return (
        <div className="sb-register-container">
            <h1>
                <FormattedMessage
                    id="app.adminRegister.title"
                    defaultMessage="Register (Sports Center Admin)"
                />
            </h1>
            <div className="sb-register-inputs-container">

                <TextField
                    label={intl.formatMessage({ id: "app.adminRegister.firstName" })}
                    className="sb-register-inputs"
                    value={registerInfo.name}
                    onChange={(e, newValue) => setRegisterInfo({ ...registerInfo, name: newValue ?? "" })}
                    validateOnFocusOut
                    validateOnLoad={false}
                    onGetErrorMessage={() => validateFieldLength(registerInfo.name)}
                    required
                />

                <TextField
                    label="Email"
                    className="sb-register-inputs"
                    value={registerInfo.email}
                    onChange={(e, newValue) => setRegisterInfo({ ...registerInfo, email: newValue ?? "" })}
                    validateOnFocusOut
                    validateOnLoad={false}
                    onGetErrorMessage={() => validateEmail(registerInfo.email)}
                    required
                />

                <TextField
                    label={intl.formatMessage({ id: "app.adminRegister.password" })}
                    type="password"
                    canRevealPassword
                    revealPasswordAriaLabel="Show password"
                    className="sb-register-inputs"
                    value={registerInfo.password}
                    onChange={(e, newValue) => setRegisterInfo({ ...registerInfo, password: newValue ?? "" })}
                    validateOnFocusOut validateOnLoad={false}
                    onGetErrorMessage={() => validateFieldLength(registerInfo.password)}
                    required
                />

                <Label required>
                    <FormattedMessage
                        id="app.register.birthDate"
                        defaultMessage="Register (Sports Center Admin)"
                    /></Label>
                <DatePicker
                    firstDayOfWeek={DayOfWeek.Sunday}
                    placeholder="Select Date of Birth"
                    ariaLabel="Select a date"
                    strings={defaultDatePickerStrings}
                    className="sb-register-date"
                    value={registerInfo.birthDate}
                    formatDate={(date?: Date): string => {
                        return moment(date).format(dateFormat)
                    }}
                    onSelectDate={(newDate: Date | null | undefined) => { if (newDate) { setRegisterInfo({ ...registerInfo, birthDate: newDate }) } }}
                />

                <TextField
                    label={intl.formatMessage({ id: "app.adminRegister.phoneNumber" })}
                    className="sb-register-inputs"
                    value={registerInfo.phoneNumber}
                    onChange={(e, newValue) => setRegisterInfo({ ...registerInfo, phoneNumber: newValue ?? "" })}
                    validateOnFocusOut validateOnLoad={false}
                    onGetErrorMessage={() => validatePhoneNumber(registerInfo.phoneNumber)}
                    required
                />

                {/* <SearchBox
                    labelText="Choose your Sports Centers (Optional)"
                    placeholder={intl.formatMessage({ id: "app.adminRegister.searchSportsCenters" })}
                    className="sb-register-inputs"
                    onSearch={(e) => setRegisterInfo({ ...registerInfo, sportsCenters: e.target.value })}
                /> */}

                <p
                    onClick={() => {
                        history.push("/sports-center-login")
                    }}
                    className="sb-login-option">
                    <FormattedMessage
                        id="app.adminRegister.loginText"
                        defaultMessage="Already have an account? Login here."
                    ></FormattedMessage>
                </p>


            </div>
            <PrimaryButton
                disabled={!formValid}
                text={intl.formatMessage({ id: "app.register.btn" })}
                className="sb-register-btn"
                onClick={handleRegister} />
        </div>
    )
}

export default RegisterAdmin;
