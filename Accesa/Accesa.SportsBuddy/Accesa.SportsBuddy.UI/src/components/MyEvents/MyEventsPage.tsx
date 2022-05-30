import ActiveEvents from './ActiveEvents'
import CreatedEvents from './CratedEvents'

const MyEventsPage = () => {
    return (
        <div className='sb-my-challenges-control-page'>
        <CreatedEvents />
        <ActiveEvents />
    </div>
    )
}

export default MyEventsPage
