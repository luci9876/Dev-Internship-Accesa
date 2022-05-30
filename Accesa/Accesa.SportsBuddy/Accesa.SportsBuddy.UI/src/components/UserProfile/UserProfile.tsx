import './UserProfile.scss';
import { UserRoleEnum } from '../../models/UserInfo';
import TrainerProfile from './TrainerProfile';
import TraineeProfile from './TraineeProfile';

export interface UserProfileProps<T> {
    user: T;
}

const UserProfile = () => {
    const data = localStorage.getItem('User');
    const user = JSON.parse(data!);

    if (user.role.id === UserRoleEnum.TRAINER) {
        return <TrainerProfile user={user} />;
    }
    return <TraineeProfile user={user} />;
}

export default UserProfile