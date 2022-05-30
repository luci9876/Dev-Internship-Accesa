import { useIntl } from "react-intl";
import { AiOutlineUser } from 'react-icons/ai';
import { BsPower } from 'react-icons/bs';

const ButtonsLoggedIn = () => {

    const intl = useIntl();

    return (
        <div className="sb-user-info">
            <abbr title="My Profile">
                <AiOutlineUser
                    className="sb-profile-picture"
                    onClick={() =>
                        window.location.href = '/profile'
                    }
                />
            </abbr>
            <abbr title="Log Out">
                <BsPower
                    className="sb-header-logout"
                    onClick={() => {
                        if (window.confirm(intl.formatMessage({ id: "app.header.logoutmessage" }))) {
                            localStorage.setItem("accountExists", "false"); //temporary, for demo purpose
                            window.location.href = '/'                      //until token is implemented
                        }

                    }
                    }
                />
            </abbr>
        </div>
    )
};

export default ButtonsLoggedIn;