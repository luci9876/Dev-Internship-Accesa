import { useEffect, useState } from "react";
import { Response } from '../../../models/Response';
import { Challenge} from '../../../models/Challenge';
import ChallengeService from '../../../services/ChallengeService';

export const useChallengeInfo = (id:number) => {
    const [response, setResponse] = useState<Response<Challenge>>();

    useEffect(() => {
        (async () => {
            setResponse(await ChallengeService.getChallengeById(id));
        })();
    }, [])

    return response;
}
