﻿using System;
using System.Collections.Generic;
using System.Numerics;

namespace SumOf50Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            var sumBigInteger = new BigInteger();

            List<string> digitList = new List<string>()
            {
                "76162310458574726027316623858418160587375550577107",
                "84738504474500403032276316550457414506634334304555",
                "36674073210348250857063068418020041816637545318327",
                "05065526055531802072432103275580810602745350611253",
                "77582627513404556211081250614818126148823256113131",
                "38132762328126833764062777341464624166884156228866",
                "64480663544118443817567788154473637107274304320517",
                "88681065814070503712356322533684355857264471345872",
                "71474323683322185146455378650655508684125213301583",
                "73407251055538267134800102318661658214250744607206",
                "20143723857322838608528631444031123581118645755253",
                "00110004022777252872374807627652810288135418718631",
                "35438242022753508678626367550880863865176588067627",
                "21734070515821227885225820372887216714231580273657",
                "88754848135066165044036545356366130005662227717184",
                "13117422174716677360583616076361612250546747240508",
                "24478183804347120033276137454664760168213104023668",
                "38156472305382205668517200611046742621043341481718",
                "55863217457513574385646141557187023770104363672145",
                "37851177215402685786042802634584117183020078403356",
                "23264840573425113745017560523083663413585871756172",
                "54886155032155806526801401357134413447028521633227",
                "70703523846868066314484063687560302263771174487318",
                "68072856387252665656025323085753778704636807884466",
                "20748326488514344738518200273374274443845287317434",
                "36170114471331033208808823117826478033633880318760",
                "65444271460864438518884658175042371628252180232348",
                "22560707851054265837182567043167267165726406425475",
                "63866300017436726850080116740425674285830655410371",
                "45764626404484816514300283346863678570260108856052",
                "33137454613604307042363441802352845222040220221457",
                "66427505764423507580740821422103446765582542050841",
                "44540165061636600756318071068614706478340158641658",
                "42267254570052458301103051403303181810138325404330",
                "47636472166412767615481527675451528256150884632076",
                "17165451187055048734014454068755073787636452683241",
                "43626026114712220622401075426516273186124265772384",
                "85025425305885065371225862251031315468288230643141",
                "17472580431642645684051810842171008455804548617032",
                "86100455526473486332786883121027102108837806207137",
                "43613882052335083603863838805850734700621683044463",
                "50007787638760024801730612607834322407558222230727",
                "85344202851786044464153425073727608707604680403416",
                "74065318281270320862466603630124550678355147728752",
                "84682073625680565106305153178747662766387320882411",
                "56787885388847670177887178741616561707827134888331",
                "70522675170345612668721486431803087002448351145666",
                "52642580342442763476182184502417532755610888238334",
                "01885584470777338088167551828542674876667007121157",
                "47432222245648271833522110684387510672416432004153",
                "01721242225378470375884260701054203683071502425362",
                "81203165403411610646762033727333270312620378353842",
                "28883272582471582202860264835788641442474866845624",
                "31723476282467837380487260022182013704065705401765",
                "61618334423530803431222145827672463647184507304853",
                "56452484634156411662543366247410540168386017428222",
                "86237020751462144153312645348368154371507607713750",
                "76588644825714813066524546148225785821678223304575",
                "72183420314855008278713773012415524838506264385632",
                "12677572084078083310586725384762683786471185554733",
                "52435158521861213741058284001505402362312812513633",
                "25223832411468154587303370456602663322528472072108",
                "67740118334656086856210577113062460242611372728011",
                "12535462518053611867332348366581018461044154116455",
                "00326681761040278331408131761227115776424522346523",
                "23031811847285427333017168756741470777066570325671",
                "62182047511530856045383654377420651284503827411606",
                "45226684275500807776624314541426600673732427468174",
                "23730218121327477802248331857343561773075824271325",
                "78152733872406666566848152131485314510324431508575",
                "05555300886824750711461424164535543387414104541820",
                "00351331211243413604522062668722445310300743026584",
                "04873663875624787871822837688350636735175715424051",
                "36664718340734148778416050164136278730876325664648",
                "25155286046342125442188811712853247645268584138034",
                "18216362444741721834782635046716677510748217101658",
                "18686164612245260531001844635332775207158636167544",
                "84347176314283683580524722636651803883843248157882",
                "32548684144305523706885352655546443354168313082727",
                "28812351758385068521676264723607273462287365654533",
                "06510325465371500024863233115182785221681174344585",
                "54373333662102634742783227777875184470528738600460",
                "86067600454447850172442228435273078044173740642580",
                "88645447371631603678058875814767453765135602564326",
                "05708386585225132678374323462115876103608081733412",
                "46423203747234702470270703735880406405440651155337",
                "07510556283668566372850385285363877032008334038644",
                "72508462242617286804233735252455314478822104612410",
                "68501376522186762836070711370136426503005125011260",
                "82138887780063846682688218446800002050276140043755",
                "43243828283407708618853154472556713565636563410518",
                "56665701873365355832220612885338620801455467838007",
                "51185258528044446354544766527737877266562141548223",
                "54452052286307810662787723822173831723465446070623",
                "32405565371380034550762063307321077477741605414456",
                "24115684322578582025456081654478401708204345247104",
                "83201560140387331776837100117424585453741067014528",
                "20325440004526146827668258601754781212308437047065",
                "34231510667481486247245281312015243014651155135120",
                "74572880402075521363625761880451722504241186313808"
            };

            for (int i = 0; i < 100; i++)
            {
                try
                {
                    sumBigInteger += BigInteger.Parse(digitList[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("1st Position Value- {0}", digitList[0]);
            Console.WriteLine("100th Position Value- {0}", digitList[99]);
            Console.WriteLine("\n\n----------The sum of following 100 numbers with 50 digits---------- \nThe Total Sum- {0}", sumBigInteger);

            Console.ReadKey();
        }
    }
}
