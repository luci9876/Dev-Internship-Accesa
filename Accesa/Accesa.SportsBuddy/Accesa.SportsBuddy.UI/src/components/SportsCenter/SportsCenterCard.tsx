import { DefaultButton} from '@fluentui/react/lib/Button';
import { useHistory } from "react-router-dom";
import { useIntl } from 'react-intl';
import './SportsCenterProfile.scss';
import { ISportsCenterProfileProps } from '../SportsCenter/SportsCenterProfile';


const CenterCard = (props: ISportsCenterProfileProps) => {
    const history = useHistory();
    const intl = useIntl();
    return (
        <article key={props.sportsCenter.id} className="sb-center-cards">
            <div className="sb-card-heading">
                <h2 className="sb-center-card-title">{props.sportsCenter.name}</h2>
            </div>
            <div className="sb-center-info">
                <ul className="sb-center-card-info">
                    <li className="sb-center-li"><span className="sb-card-description"> {intl.formatMessage({ id: "app.centerProfile.name" })}:</span> {props.sportsCenter.name}</li>
                    <li><span className="sb-card-description"> {intl.formatMessage({ id: "app.centerProfile.Street" })}:</span> {props.sportsCenter.addressNavigation.street}</li>
                    <li><span className="sb-card-description"> {intl.formatMessage({ id: "app.centerProfile.City" })}:</span> {props.sportsCenter.addressNavigation.city}</li>

                </ul>
                {
                    <div className="sb-center-edit">
                        <DefaultButton text={intl.formatMessage({ id: "app.sportsCenterProfile.title" })} className="sb-btn-center" onClick={() => history.push('/sportscenterprofile', props.sportsCenter)} />
                    </div>
                }
            </div>
        </article >
    )
}
export default CenterCard;
