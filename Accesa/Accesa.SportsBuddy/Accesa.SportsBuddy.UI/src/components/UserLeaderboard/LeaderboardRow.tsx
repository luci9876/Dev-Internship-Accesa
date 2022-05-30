import React, { ReactNode } from 'react'
import { Trainee } from '../../models/Trainee'
export interface LeaderboardProps {
    user: Trainee,
    place: number | ReactNode
}

const LeadeboardRow: React.FC<LeaderboardProps> = ({ user, place }) => {

    let ranking = {
        image: '',
        myPlace: ''
    }

    if (place === 1) {
        ranking = {
            image: '/gold.png',
            myPlace: '1st place'
        }
    }
    if (place === 2) {
        ranking = {
            image: '/silver.png',
            myPlace: '2nd place'
        }
    }
    if (place === 3) {
        ranking = {
            image: '/bronze.png',
            myPlace: '3th place'
        }
    }

    return (
        <tr>
            <td>{place! > 3 ? `#${place}` : <img className='sb-leaderboard-rank' src={ranking.image} alt={ranking.myPlace} />}</td>
            <td>{user.firstName} {user.lastName}</td>
            <td>{user.score}</td>
        </tr>
    )
}

export default LeadeboardRow