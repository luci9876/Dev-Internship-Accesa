import { FormattedMessage } from 'react-intl';
import './SuccessMessage.scss';

export interface SuccessMessageProps {
    shouldShowSuccessMessage: boolean,
    id: string
}

const SuccessMessage: React.FC<SuccessMessageProps> = ({ shouldShowSuccessMessage, id }) => {
    return (
        shouldShowSuccessMessage ?
            <div className="sb-success-message">
                <div className="sb-success-message-container">
                    <p><FormattedMessage
                        id={id} /></p>
                </div>
            </div>
            : <div></div>
    )
}

export default SuccessMessage
