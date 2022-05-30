import { useState } from 'react';
import { FormattedMessage } from 'react-intl';
import './SportsCenterProfile.scss';
import { SportsCenter } from '../../models/SportsCenters';
import { useCallback } from 'react';
import CenterService from '../../services/CenterService';
import { useEffect } from 'react';
import Carousel from 'react-elastic-carousel';
import CenterCard from '../SportsCenter/SportsCenterCard';
import { DEFAULT_ERROR, ResponseError } from '../../models/Response';
import ErrorMessage from '../ErrorMessage/ErrorMessage';

const SportsCenterList = () => {

    const [centers, setCenters] = useState<SportsCenter[]>([]);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);

    const getAllSportCenters = useCallback(async () => {
        const sportCenters = await CenterService.getAllCenters();
        if (!sportCenters.hasError) {
            setCenters(sportCenters.data);
            setHasError(sportCenters.hasError);
        }
        else {
            setError({
                errorCode: sportCenters.errorCode,
                errorMessage: sportCenters.errorMessage
            })
            setHasError(sportCenters.hasError);
        }
    }, []);
    useEffect(() => {

        getAllSportCenters();
    }, [getAllSportCenters])

    const itemsBreakpoints = [
        { width: 1, itemsToShow: 1, itemsToScroll: 1 },
        { width: 750, itemsToShow: 2, itemsToScroll: 2 },
        { width: 1024, itemsToShow: 3, itemsToScroll: 2 },

    ]
    return (
        hasError ?
            <ErrorMessage responseError={error} />
            : <div className="sb-centers-list-outer-container">
                <h2 className="sb-center-title" >
                    <FormattedMessage
                        id="app.CenterProfile.title"
                        defaultMessage="List Of Sports Centers" />
                </h2>
                <section className="sb-center-card">
                    <Carousel breakPoints={itemsBreakpoints} isRTL={false}>
                        {centers.map((element: SportsCenter) => (<CenterCard key={element.id} sportsCenter={element} />))}
                    </Carousel>
                </section>
            </div>
    )
}

export default SportsCenterList;