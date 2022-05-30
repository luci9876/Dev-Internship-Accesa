import { TrainingProgram } from '../../models/TrainingProgram';
import planking from '../../assets/planking.jpg';
import { ScrollablePane, Sticky, StickyPositionType } from '@fluentui/react';

type ActivityStepsProps = {
    element: TrainingProgram
}

const ActivitySteps = (props: ActivityStepsProps) => {

    const createContentArea = (item: string, index: number) => (
        <div key={index} >

            <article className="sb-activity-steps-outer">
                <div className="sb-activity-steps-container">
                    <Sticky stickyPosition={StickyPositionType.Both}>
                        <div role="heading" aria-level={1}>
                            Step {index + 1}
                        </div>
                    </Sticky>
                    <p className="sb-steps-text">{item}</p>
                    <img src={planking} alt="Man doing pushups" className="sb-steps-img"></img>
                </div>
            </article>

        </div>
    )

    return (
        <section className="sb-activity-steps-section">
            <ScrollablePane
                scrollContainerFocus={true}
                scrollContainerAriaLabel="Sticky component example"
                style={{ maxWidth: 420, maxHeight: 800, marginTop: 30}}
            >
                {props.element.trainingProgramRecommendedSteps.map(createContentArea)}
            </ScrollablePane>
        </section>
    )
}

export default ActivitySteps;