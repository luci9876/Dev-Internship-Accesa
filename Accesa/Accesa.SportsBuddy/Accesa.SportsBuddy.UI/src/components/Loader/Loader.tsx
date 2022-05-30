import { IStackProps, Stack } from '@fluentui/react/lib/Stack';
import { Spinner, SpinnerSize } from '@fluentui/react/lib/Spinner';
import './Loader.scss';

const Loader = () => {
    const rowProps: IStackProps = { horizontal: true, verticalAlign: 'center' };

    const tokens = {
        spinnerStack: {
            childrenGap: 30,
        },
    };
    return (
        <div className="sb-spinner-container">
            <div className="sb-spinner">
            <Stack {...rowProps} tokens={tokens.spinnerStack}>
                <Spinner size={SpinnerSize.large} />
            </Stack>
            </div>
        </div>
    )
}

export default Loader;