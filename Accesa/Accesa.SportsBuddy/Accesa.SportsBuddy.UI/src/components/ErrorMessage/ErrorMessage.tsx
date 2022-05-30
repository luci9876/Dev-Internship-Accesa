import './ErrorMessage.scss';
import React from 'react';
import { DefaultButton } from '@fluentui/react/lib/Button';
import { useHistory } from 'react-router-dom';
import { ResponseError } from '../../models/Response';

export interface ErrorProps {
    responseError: ResponseError,
}

const ErrorMessage: React.FC<ErrorProps> = ({responseError}) => {
    let history = useHistory();

    return (
        <div className = 'sb-error-message-page'>
            <section className='sb-error-message-main'>
            <img src="/error.png" alt="error" />
            <div className= 'sb-error-message-response-text'>
                <p className='sb-error-message-code'>{responseError.errorCode}</p>
                <p className='sb-error-message-description'>{responseError.errorMessage}</p>
            </div>
            </section>
            <section>
                <p>Oops... It looks like something went wrong. Please return to the home page.</p>
                <DefaultButton
                        text="Home Page"
                        onClick={() => {
                            history.push("/");
                        }} />
            </section>
        </div>
    )
}

export default ErrorMessage
