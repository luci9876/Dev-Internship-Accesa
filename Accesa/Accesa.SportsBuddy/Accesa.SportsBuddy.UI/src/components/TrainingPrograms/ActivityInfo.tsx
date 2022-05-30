import { TrainingProgram } from '../../models/TrainingProgram';
import './Activity.scss';
import './ActivityDetails.scss';
import ActivityActions from "../../components/TrainingPrograms/ActivityActions";
import ActivitySteps from "../../components/TrainingPrograms/ActivitySteps";
import ActivityDetails from "../../components/TrainingPrograms/ActivityDetails";
import ReviewCard from "../Review/ReviewCard";
import AddReviewCard from "../Review/AddReviewCard";
import { DefaultButton, FontIcon, PrimaryButton } from '@fluentui/react';
import { useState } from 'react';
import { useIntl } from 'react-intl';

type ActivityInfoProps = {
    element: TrainingProgram,
    handleEditMode?: any,
    handleAddMode?: any,
}

const ActivityInfo = (props: ActivityInfoProps) => {

    const intl = useIntl();

    const [activityStatus, setActivityStatus] = useState(false);
    const [addComment, setAddComment] = useState(false);
    const [shouldRefreshReview, setShouldRefreshReviews] = useState(false);

    const handleActivityStatus = () => {
        setActivityStatus(true);
    }

    const handleAddComment = () => {
        setAddComment(!addComment);
    }

    return (
        <section className="sb-activity-info-section">
            <ActivityActions element={props.element} handleAddMode={props.handleAddMode} handleEditMode={props.handleEditMode}/>
            <div className="sb-activity-split-elements">
                <div className="sb-activity-left-elements">
                    <ActivityDetails element={props.element} />
                    <DefaultButton
                        text={intl.formatMessage({ id: "app.activity.start-btn" })}
                        allowDisabledFocus
                        className="sb-activity-start-btn"
                        onClick={handleActivityStatus} />
                    {
                        activityStatus ? <ActivitySteps element={props.element} /> : ""
                    }
                </div>
                <div className="sb-review-section">
                    <h2 className="sb-activity-update-title"> {intl.formatMessage({ id: "app.review-section" })}</h2>
                    <ReviewCard trainingId={props.element.trainingProgramId} shouldRefresh={shouldRefreshReview} />
                    <FontIcon
                        className="sb-comment-add-icon"
                        aria-label="ChartIcon"
                        iconName="CircleAdditionSolid"
                        onClick={handleAddComment} />
                    {
                        addComment ? <AddReviewCard trainingId={props.element.trainingProgramId} setShouldRefreshReviews={setShouldRefreshReviews} /> : ""
                    }
                </div>
            </div>
        </section>
    )
}

export default ActivityInfo;