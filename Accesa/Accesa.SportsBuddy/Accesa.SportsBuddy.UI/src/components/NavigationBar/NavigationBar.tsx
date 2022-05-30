import './NavigationBar.scss';
import { Nav, INavStyles, INavLinkGroup } from '@fluentui/react/lib/Nav';
import { Trainer } from '../../models/Trainer';
import { GenderEnum, UserRoleEnum } from '../../models/UserInfo';
import routes from '../../helpers/routes';
import { useContext } from 'react';
import { SideBarContext } from '../../SideBarContext';
import { useEffect } from 'react';
import { useIntl } from 'react-intl';

//mock data for testing - waiting for api
const user: Trainer = {
    trainerId: 1,
    id: 753,
    firstName: 'John',
    lastName: 'Doe',
    email: 'john.doe@something.com',
    addressNavigation: {
        id: 0,
        street: '',
        city: '',
        state: '',
        postalCode: '',
        country: '',
    },
    isAvailable: true,
    birthDate: new Date("10-19-1984"),
    gender: GenderEnum.MALE,
    phoneNumber: '1234567890',
    createdAt: new Date("08-04-2021"),
    role: {
        id: UserRoleEnum.TRAINER,
        name: 'trainer'
    },
    picture: '/default.jpg',
    rating: 8.7,
};


const NavigationBar = () => {
    
    const displayDashboard = (user: Trainer) => {
        if (user.role.id === UserRoleEnum.ADMIN) {
            return {
                name: `${intl.formatMessage({ id: "app.nav.SportCenters" })}`,
                url: '/sportscenterlist',
                key: 'key4',
            }
        }
        if (user.role.id === UserRoleEnum.TRAINER) {
            return {
                name: `${intl.formatMessage({ id: "app.nav.Trainings" })}`,
                url: routes.trainerDashboard,
                key: 'key7',
            }
        }
        return {
            name: 'Trainings Dashboard',
            url: routes.trainerDashboard,
            key: 'key8',
        }
    }
    
    const intl = useIntl();

    const navStyles: Partial<INavStyles> = {
        root: {
            width: 208,
            height: 350,
            boxSizing: 'border-box',
            overflowY: 'auto',
        },
    };

    const navLinkGroups: INavLinkGroup[] = [
        {
            links: [
                {
                    name: `${intl.formatMessage({ id: "app.nav.Home" })}`,
                    url: '/',
                    key: '/Home'

                },
                {
                    name: `${intl.formatMessage({ id: "app.nav.Profile" })}`,
                    url: routes.profile,
                    key: '/profile',
                },
                {
                    name: `${intl.formatMessage({ id: "app.nav.Challenges" })}`,
                    url: '/challenges',
                    key: '/challenges',
                },
                {
                    name: `${intl.formatMessage({ id: "app.nav.Leaderboard" })}`,
                    url: '/leaderboard',
                    key: '/leaderboard',
                },
                {
                    name: `${intl.formatMessage({ id: "app.nav.Events" })}`,
                    url: '/events',
                    key: '/events',
                },
                displayDashboard(user),
            ],
        },
    ];

    const { sideBar, setSideBar } = useContext(SideBarContext);

    let sideBarRef = document.querySelector("Nav");

    useEffect(() => {
        let handler = (event: MouseEvent) => {
            if (!sideBarRef?.contains(event.target as Node)) {
                setSideBar(false);
            }
        };
        document.addEventListener("mousedown", handler);
        return () => {
            document.removeEventListener("mousedown", handler);
        }
    })

    return (
        <Nav
            initialSelectedKey="/user-main-page"
            selectedKey={window.location.pathname}
            ariaLabel="Nav basic example"
            styles={navStyles}
            groups={navLinkGroups}
            className={sideBar ? "sb-navigation" : "sb-navigation hidden"}
        />
    )
};

export default NavigationBar;