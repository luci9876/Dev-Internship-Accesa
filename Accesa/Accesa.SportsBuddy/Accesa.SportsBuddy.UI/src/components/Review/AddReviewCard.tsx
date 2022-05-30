import { useState } from "react";
import { Review } from "../../models/Review";
import { PrimaryButton, TextField } from '@fluentui/react';
import FieldValidatorService from "../../services/FieldValidatorService";
import ReviewService from "../../services/ReviewService";
import { useIntl } from "react-intl";
import { useHistory } from "react-router-dom";

type AddReviewProps = {
    trainingId: number,
    setShouldRefreshReviews: any
}
const AddReviewCard = (props: AddReviewProps) => {

    const intl = useIntl();
    const history=useHistory();
    const user = JSON.parse(localStorage.getItem('User')!)

    const [reviewInfo, setReviewInfo] = useState<Review>({
        rating: 0,
        comment: "",
        traineeId: user.id,
        traineeFirstName: user.firstName,
        traineeLastName: user.lastName,
        trainingId: props.trainingId,
        createdAt: new Date()
    })

    const validateLength = (value: string) => {
        return FieldValidatorService.validateFieldLength(value);
    }

    const handleReviewAdd = async () => {
        await ReviewService.addReview(reviewInfo, props.setShouldRefreshReviews);
        setReviewInfo({...reviewInfo, comment: "", rating: 0})
        history.go(0);
    };

    return (
        <div className="sb-review-add-card">
            <TextField
            value={reviewInfo.comment}
                placeholder={intl.formatMessage({ id: "app.review-comment" })}
                className="sb-review-comment"
                multiline rows={3}
                onChange={(event, newValue?: string) => setReviewInfo({ ...reviewInfo, comment: newValue! })}
                validateOnFocusOut
                validateOnLoad={false}
                onGetErrorMessage={() => validateLength(reviewInfo.comment)}
            />
            <TextField
                value={reviewInfo.rating.toLocaleString()}
                label={intl.formatMessage({ id: "app.review-rating" })}
                className="sb-review-user-rating"
                onChange={(event, newValue) => setReviewInfo({ ...reviewInfo, rating: +newValue! })}
            />
            <PrimaryButton
                text={intl.formatMessage({ id: "app.review-add" })}
                className="sb-review-comment-btn"
                allowDisabledFocus
                onClick={handleReviewAdd} />
        </div>
    )
}

export default AddReviewCard;