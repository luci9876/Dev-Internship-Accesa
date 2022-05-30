import { TextField } from '@fluentui/react/lib/TextField';
import { PrimaryButton } from '@fluentui/react/lib/Button';
import './LoginAdmin.scss';
import { useCallback, useState } from 'react';
import AuthService from '../../services/AuthService';
import { useHistory } from 'react-router-dom';
import { useIntl, FormattedMessage } from 'react-intl';
import { LoginInfo } from '../../models/UserInfo';
import FieldValidatorService from '../../services/FieldValidatorService';

function LoginAdmin() {

    let history = useHistory();
    const intl = useIntl();
    const [error, setError] = useState('');
    const [loginInfo, setLoginInfo] = useState<LoginInfo>({
        email: "",
        password: ""
    });


    const validateFieldLength = (value: string) => {
        return FieldValidatorService.validateFieldLength(value);
    }

    const validateEmail = (value: string) => {
        return FieldValidatorService.validateEmail(value);
    }

    const formValid = loginInfo.email.length && loginInfo.password.length;


    const handleLogin = useCallback(async () => {
        const response = await AuthService.adminLogin(loginInfo);
        if (!response.hasError) {
            setError('');
        }
        else {
            setLoginInfo({
                email: '',
                password: ''
            })
            setError('E-mail or password incorect. Please try again.')
        }
    }, [loginInfo]);

    return (
        <div className="sb-login-container">
            <h1>
                <FormattedMessage
                    id="app.adminLogin.title"
                    defaultMessage="Login (Sports Center Admin)"
                />
            </h1>
            <div className="sb-login-form">
                <TextField
                    label={intl.formatMessage({ id: "app.adminLogin.emailLabel" })}
                    placeholder={intl.formatMessage({ id: "app.adminLogin.emailPlaceholder" })}
                    className="sb-login-inputs"
                    value={loginInfo.email}
                    onChange={(e, newValue) => setLoginInfo({ ...loginInfo, email: newValue ?? "" })}
                    validateOnFocusOut
                    validateOnLoad={false}
                    onGetErrorMessage={() => validateEmail(loginInfo.email)}
                    required
                />
                <TextField
                    label={intl.formatMessage({ id: "app.adminLogin.passwordLabel" })}
                    placeholder={intl.formatMessage({ id: "app.adminLogin.passwordPlaceholder" })}
                    className="sb-login-inputs"
                    type="password"
                    canRevealPassword
                    revealPasswordAriaLabel="Show password"
                    value={loginInfo.password}
                    onChange={(e, newValue) => setLoginInfo({ ...loginInfo, password: newValue ?? "" })}
                    validateOnFocusOut validateOnLoad={false}
                    onGetErrorMessage={() => validateFieldLength(loginInfo.password)}
                    required
                />

                <p
                    onClick={() => {
                        history.push("/sports-center-register");
                    }}
                    className="sb-register-option">
                    <FormattedMessage
                        id="app.adminLogin.registerText"
                        defaultMessage="Don't have an admin account? Register now!"
                    ></FormattedMessage>
                </p>
                <p className='sb-login-error-message'>{error}</p>




            </div>
            <PrimaryButton
                disabled={!formValid}
                text="Login"
                className="sb-login-btn"
                onClick={handleLogin} />
        </div>
    )

}

export default LoginAdmin;
