import { FormattedMessage } from 'react-intl';
import './Footer.scss';
import {FaFacebookSquare, FaInstagram, FaYoutube, FaLinkedin, FaPeriscope} from 'react-icons/fa';

const Footer = () => {
    return (
        <div className="sb-footer-container">
            <div className="sb-social-container">
                <h6>
                    <FormattedMessage
                        id="app.footer.text1"
                        defaultMessage="You can find us here"
                    />
                </h6>
                <a target="_blank" rel="noreferrer" href="https://www.facebook.com/accesa.eu">
                    <FaFacebookSquare className="sb-social-icon"/>
                </a>
                <a target="_blank" rel="noreferrer" href="https://www.instagram.com/accesapeople/">
                    <FaInstagram className="sb-social-icon" />
                </a>
                <a target="_blank" rel="noreferrer" href="https://www.youtube.com/user/AccesaConsulting">
                    <FaYoutube className="sb-social-icon" />
                </a>
                <a target="_blank" rel="noreferrer" href="https://www.linkedin.com/company/accesa-eu/mycompany/">
                    <FaLinkedin className="sb-social-icon" />
                </a>
                <a target="_blank" rel="noreferrer" href="https://goo.gl/maps/4NbtCPnVpu15YwwJ8">
                    <FaPeriscope className="sb-social-icon" />
                </a>
            </div>
            <h6>
                <FormattedMessage
                    id="app.footer.text2"
                    defaultMessage="Thank you for using &copy;SportsBuddy by Accesa interns. All rights reserved."
                />
            </h6>
        </div>
    )
}

export default Footer;