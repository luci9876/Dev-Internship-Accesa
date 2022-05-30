import planking from '../../assets/planking.jpg';
import './ReviewCard.scss';
import { useCallback, useEffect, useState } from 'react';
import { Review } from '../../models/Review';
import ReviewService from '../../services/ReviewService';
import { useIntl } from 'react-intl';
import moment from 'moment';
import { DEFAULT_ERROR, ResponseError } from '../../models/Response';
import ErrorMessage from '../ErrorMessage/ErrorMessage';

type ReviewProps = {
    trainingId: number,
    shouldRefresh: boolean
}

const ReviewCard = (props: ReviewProps) => {

    const intl = useIntl()

    const [reviews, setReviews] = useState<Review[]>([]);
    const [error, setError] = useState<ResponseError>(DEFAULT_ERROR);
    const [hasError, setHasError] = useState<boolean>(false);

    const dateFormat = intl.formatMessage({ id: "app.date-format" });

    const getReviewsByTrainingId = useCallback(async () => {
        const reviews = await ReviewService.getReviewsByTrainingId(props.trainingId);
        if (!reviews.hasError) {
            setReviews(reviews.data);
            setHasError(reviews.hasError);
        }
        else {
            setError({
                errorCode: reviews.errorCode,
                errorMessage: reviews.errorMessage
            })
            setHasError(reviews.hasError);
        }
    }, [props.trainingId]);

    useEffect(() => {

        getReviewsByTrainingId();

    }, [getReviewsByTrainingId, props.shouldRefresh])

    return (
        hasError ?
            <ErrorMessage responseError={error} />
            : <div className="sb-review-container">

                {
                    reviews && reviews.length ? reviews.map((element) => (
                        <figure key={element.id} className="sb-review">
                            <blockquote className="sb-review-text">
                                <em>
                                    {element.comment}
                                </em>
                            </blockquote>
                            <figcaption className="sb-review-user">
                                <div className="sb-review-user-pic-and-info">
                                    <img src={planking} alt="User " className="sb-review-photo" />
                                    <div className="sb-review-user-box">
                                        <p className="sb-review-user-name">{element.traineeFirstName.toLocaleUpperCase()} {element.traineeLastName.toLocaleUpperCase()}</p>
                                        <p className="sb-review-user-date">{moment(element.createdAt).format(dateFormat)}</p>
                                    </div>
                                </div>
                                <div className="sb-review-rating">{element.rating}</div>
                            </figcaption>
                        </figure>
                    )) : intl.formatMessage({ id: "app.review-no-reviews" })
                }
            </div>
    )
}

export default ReviewCard;