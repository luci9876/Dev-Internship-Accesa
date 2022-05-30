import { FormattedMessage } from 'react-intl';
import LoginComponent from '../../LoginUser/components/LoginComponent';
import './LandingPage.scss';
import UserMainPage from './UserMainPage';

const LandingPage = () => {
    return (
        <div className="sb-landing-container-full"> 
        <div className="sb-landing-container">
            <div className="sb-landing-titlearea">
                <h1>
                    <FormattedMessage
                        id="app.landing.p1"
                        defaultMessage="WELCOME!"
                    />
                </h1>
                <h3>
                    <FormattedMessage
                        id="app.landing.p2"
                        defaultMessage="DO YOU LOVE SPORTS AND WORKOUT, OR JUST WANT TO GET IN SHAPE?"
                    />
                </h3>
                <h3>
                    <FormattedMessage
                        id="app.landing.p3"
                        defaultMessage="ARE YOU LOOKING FOR A TRAINER, OR MAYBE YOU ARE A TRAINER AND WANT TO TEACH OTHERS?"
                    />
                </h3>
                <h3>
                    <FormattedMessage
                        id="app.landing.p4"
                        defaultMessage="YOU WANT TO SHARE OR ATTEND A SPORTS EVENT?"
                    />
                </h3>
                <h3>
                    <FormattedMessage
                        id="app.landing.p5"
                        defaultMessage="YOU ARE IN THE RIGHT PLACE!"
                    />
                </h3>
                <h4>
                    <FormattedMessage
                        id="app.landing.p6"
                        defaultMessage="SportsBuddy is the place where it can all come to life. Learn to train with verified professionals,
                        share your own workouts with the world, and participate in sport events hosted by centers in your city."
                    />
                </h4>
            </div>
            <UserMainPage />
        </div>
        </div>
    )
}

export default LandingPage;