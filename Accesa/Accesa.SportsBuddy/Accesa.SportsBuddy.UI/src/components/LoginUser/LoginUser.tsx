import './LoginUser.scss';
import '../../services/TraineeService'
import { FormattedMessage } from 'react-intl';
import LoginComponent from './components/LoginComponent'


const LoginUser = () => {
    return (
        <div className="sb-login-container-full">
         <div className="sb-login-container">
            <h1 className="sb-login-label">
                <FormattedMessage
                    id="app.login.title"
                    defaultMessage="Login"
                />
            </h1>
            <LoginComponent />
        </div >
        </div>
    )
};

export default LoginUser;