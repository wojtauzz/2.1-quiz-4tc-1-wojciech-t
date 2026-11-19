namespace QuizBobry.Models;

public static class QuestionBank
{
    public static List<Question> GetQuestions() =>
    [
        new()
        {
            Text = "Ile gatunków bobrów występuje na świecie?",
            Answers = ["2 — europejski i kanadyjski", "4 — europejski, kanadyjski, azjatycki i afrykański", "1 — bóbr pospolity"],
            CorrectIndex = 0,
            Explanation = "Na świecie żyją dwa gatunki bobrów: bóbr europejski (Castor fiber) i bóbr kanadyjski (Castor canadensis)."
        },
        new()
        {
            Text = "Co jest głównym budulcem tam bobrowych?",
            Answers = ["Kamienie i glina", "Gałęzie, błoto i drewno", "Trawa i liście"],
            CorrectIndex = 1,
            Explanation = "Bobry budują tamy głównie z gałęzi, błota, kamieni i drewna. Potrafi to być naprawdę solidna konstrukcja!"
        },
        new()
        {
            Text = "Jak długo bóbr potrafi przebywać pod wodą bez wynurzania się?",
            Answers = ["Około 2 minuty", "Do 15 minut", "Ponad godzinę"],
            CorrectIndex = 1,
            Explanation = "Bobry potrafią wstrzymać oddech nawet do 15 minut, co pozwala im swobodnie pracować pod wodą."
        },
        new()
        {
            Text = "Czym głównie żywią się bobry?",
            Answers = ["Rybami i owadami wodnymi", "Korą drzew, pędami i roślinami wodnymi", "Małymi ssakami i ptakami"],
            CorrectIndex = 1,
            Explanation = "Bobry są roślinożercami — jedzą korę drzew (zwłaszcza osik i wierzb), pędy, trawy i rośliny wodne."
        },
        new()
        {
            Text = "Jaka jest charakterystyczna cecha ogona bobra?",
            Answers = ["Jest długi i puszysty", "Jest płaski i pokryty łuskami", "Jest krótki i zakończony pędzelkiem"],
            CorrectIndex = 1,
            Explanation = "Ogon bobra jest płaski, łopatkowaty i pokryty łuskami. Służy jako ster podczas pływania i podpórka na lądzie."
        },
        new()
        {
            Text = "Dlaczego zęby bobrów mają pomarańczowy kolor?",
            Answers = ["Bo jedzą dużo marchwi", "Bo zawierają żelazo, które je wzmacnia", "Bo nie myją zębów"],
            CorrectIndex = 1,
            Explanation = "Szkliwo zębów bobrów zawiera związki żelaza, dzięki czemu są niezwykle twarde i mają charakterystyczny pomarańczowy kolor."
        },
        new()
        {
            Text = "Jak nazywa się dom bobra zbudowany na wodzie?",
            Answers = ["Nora", "Żeremia", "Kopiec"],
            CorrectIndex = 1,
            Explanation = "Dom bobra nazywa się żeremią. To kopulasta budowla z gałęzi i błota, z wejściem pod wodą."
        },
        new()
        {
            Text = "Czy zęby bobra rosną przez całe życie?",
            Answers = ["Tak, dlatego musi je ścierać gryząc drewno", "Nie, wymieniają się co 2 lata", "Tak, ale tylko do 5. roku życia"],
            CorrectIndex = 0,
            Explanation = "Siekacze bobrów rosną nieprzerwanie przez całe życie — gryzienie drewna je naturalnie ściera i utrzymuje właściwą długość."
        },
        new()
        {
            Text = "Ile przeciętnie waży dorosły bóbr europejski?",
            Answers = ["5–10 kg", "20–30 kg", "50–60 kg"],
            CorrectIndex = 1,
            Explanation = "Dorosły bóbr europejski waży zazwyczaj 20–30 kg, co czyni go największym gryzoniem Europy."
        },
        new()
        {
            Text = "Jaki wpływ mają tamy bobrów na środowisko?",
            Answers = ["Wyłącznie negatywny — niszczą lasy", "Pozytywny — tworzą mokradła zwiększające bioróżnorodność", "Żaden — tamy są zbyt małe"],
            CorrectIndex = 1,
            Explanation = "Tamy bobrów tworzą mokradła, które zwiększają bioróżnorodność, filtrują wodę i pomagają zapobiegać powodziom. Bobry są nazywane \u201Einżynierami ekosystemów\u201D."
        }
    ];
}
