export class ExamResultsDTO {
    ExamId: string;
    QuestionIdToAnswerIdMap: Map<string, string>;

    constructor(examId: string, questionIdToAnswerIdMap: Map<string, string>) {
        this.ExamId = examId;
        this.QuestionIdToAnswerIdMap = questionIdToAnswerIdMap;
    }

    ToJSON() {
        const qIdaIdMapJSON = {};
        this.QuestionIdToAnswerIdMap.forEach((value, key) => {
            qIdaIdMapJSON[key] = value;
        });
        const examResultsDTO = { "ExamId": this.ExamId, "QuestionIdToAnswerIdMap": qIdaIdMapJSON };
        return examResultsDTO;
    }
}