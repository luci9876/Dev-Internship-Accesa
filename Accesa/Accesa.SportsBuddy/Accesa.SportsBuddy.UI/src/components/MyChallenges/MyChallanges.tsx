import './MyChallenges.scss';
import CreatedChallenges from './CreatedChallanges';
import ActiveChallenges from './ActiveChallenges';

const MyChallanges = () => {
    return (
        <div className='sb-my-challenges-control-page'>
            <CreatedChallenges />
            <ActiveChallenges />
        </div>
    )
}

export default MyChallanges
