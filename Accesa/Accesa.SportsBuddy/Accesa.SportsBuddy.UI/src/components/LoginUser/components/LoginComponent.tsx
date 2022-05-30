import { TextField } from '@fluentui/react/lib/TextField';
import { PrimaryButton } from '@fluentui/react/lib/Button';
import { useHistory } from 'react-router-dom';
import { LoginInfo } from '../../../models/UserInfo';
import FieldValidatorService from '../../../services/FieldValidatorService';
import AuthService from '../../../services/AuthService';
import { useState } from 'react';
import { FormattedMessage, useIntl } from 'react-intl';
import { Label } from "@fluentui/react";
import '../LoginUser.scss';
import '../../../services/TraineeService';

const LoginComponent = () => {


    let history = useHistory();
    const intl = useIntl();
    const [error, setError] = useState('');
    const [loginInfo, setLoginInfo] = useState<LoginInfo>({
        email: '',
        password: ''
    });

    const validateFieldLength = (value: string) => {
        return FieldValidatorService.validateFieldLength(value);
    };

    const validateEmail = (value: string) => {
        return FieldValidatorService.validateEmail(value);
    };

    const formValid = loginInfo.email.length && loginInfo.password.length;

    const handleLogin = async () => {
        const response = await AuthService.userLogin(loginInfo);
        if (!response.hasError) {
            setError('');
            history.push('/');
            window.location.reload();
        }
        if (response.hasError) {
            setLoginInfo({
                email: '',
                password: ''
            });
            setError('E-mail or password incorect. Please try again.');
        };
    };

    return (
        <>
            <div className="sb-login-form">
                <Label className="sb-login-labels" required>
                    <FormattedMessage
                        id="app.login.emailLabel"
                    /></Label>
                <TextField
                    placeholder={intl.formatMessage({ id: "app.login.emailPlaceholder" })}
                    className="sb-login-inputs"
                    value={loginInfo.email}
                    onChange={(e, newValue) => setLoginInfo({ ...loginInfo, email: newValue! })}
                    validateOnFocusOut
                    validateOnLoad={false}
                    onGetErrorMessage={() => validateEmail(loginInfo.email)}
                    required
                />
                <Label className="sb-login-labels" required>
                    <FormattedMessage
                        id="app.login.passwordLabel"
                    /></Label>
                <TextField
                    placeholder={intl.formatMessage({ id: "app.login.passwordPlaceholder" })}
                    className="sb-login-inputs"
                    type="password"
                    canRevealPassword
                    revealPasswordAriaLabel="Show password"
                    value={loginInfo.password}
                    onChange={(e, newValue) => setLoginInfo({ ...loginInfo, password: newValue! })}
                    validateOnFocusOut validateOnLoad={false}
                    onGetErrorMessage={() => validateFieldLength(loginInfo.password)}
                    required
                />

                <p
                    onClick={() => {
                        history.push("/register");
                    }}
                    className="sb-register-option">
                    <FormattedMessage
                        id="app.login.registerText"
                        defaultMessage="Don't have an account? Register now!"
                    ></FormattedMessage>
                </p>
                <p className='sb-login-error-message'>{error}</p>


            </div>
            <PrimaryButton
                disabled={!formValid}
                text="Login"
                className="sb-login-btn"
                onClick={handleLogin} />
        </>
    )
};

export default LoginComponent;