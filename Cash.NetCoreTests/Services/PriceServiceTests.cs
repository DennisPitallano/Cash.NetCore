﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cash.NetCoreTests.Services;

[TestClass]
public class PriceServiceTests : TestBase
{
    private IPriceService? _priceService;

    [TestInitialize]
    public void PriceServiceTest()
    {
        _priceService = _serviceProvider.GetService<IPriceService>();
    }

    [TestMethod]
    public async Task GetRatesAsyncTest()
    {
        var info = await _priceService!.GetRatesAsync();
        var ratesInfo = new Dictionary<string, string>
        {
            {"AED", "1383.5649425"},
            {"AFN", "33404.708575875"},
            {"ALL", "41461.80076285"},
            {"AMD", "182152.2870687"},
            {"ANG", "680.096129375"},
            {"AOA", "167459.91145"},
            {"ARS", "41888.897855025"},
            {"AUD", "502.8852322"},
            {"AWG", "678.015"},
            {"AZN", "640.3475"},
            {"BAM", "666.87672025"},
            {"BBD", "753.35"},
            {"BDT", "32537.899545775"},
            {"BGN", "667.091425"},
            {"BHD", "142.149988175"},
            {"BIF", "774259.720057525"},
            {"BMD", "376.675"},
            {"BND", "511.657616275"},
            {"BOB", "2598.11355245"},
            {"BRL", "1755.611736775"},
            {"BSD", "376.675"},
            {"BTN", "28663.125935925"},
            {"BWP", "4330.03054835"},
            {"BYN", "1229.0558709"},
            {"BYR", "12290558.70899999924665"},
            {"BZD", "760.633011125"},
            {"CAD", "471.702569"},
            {"CDF", "754774.6089572"},
            {"CHF", "348.685410775"},
            {"CLF", "10.744654375"},
            {"CLP", "296473.149945375"},
            {"CNY", "2396.8206925"},
            {"COP", "1423783.22909875"},
            {"CRC", "247314.94440185"},
            {"CUC", "376.675"},
            {"CVE", "37761.66875"},
            {"CZK", "8308.320475"},
            {"DJF", "67181.0620338"},
            {"DKK", "2535.6630975"},
            {"DOP", "20758.516685725"},
            {"DZD", "53973.985624975"},
            {"EGP", "6890.637441025"},
            {"ETB", "19388.199402975"},
            {"EUR", "340.585"},
            {"FJD", "787.55209"},
            {"FKP", "287.220337625"},
            {"GBP", "287.165"},
            {"GEL", "1165.809125"},
            {"GHS", "2839.656019525"},
            {"GIP", "287.220337625"},
            {"GMD", "20302.7825"},
            {"GNF", "3371302.304874075"},
            {"GTQ", "2900.0072647"},
            {"GYD", "78947.91065655"},
            {"HKD", "2950.7589475"},
            {"HNL", "9262.75691705"},
            {"HRK", "2580.963163025"},
            {"HTG", "40188.959059925"},
            {"HUF", "125360.6417375"},
            {"IDR", "5413365.92875"},
            {"ILS", "1205.699384175"},
            {"INR", "28610.198955"},
            {"IQD", "550763.602315875"},
            {"ISK", "48417.5498677"},
            {"JMD", "57851.145094275"},
            {"JOD", "267.062575"},
            {"JPY", "46145.324225"},
            {"KES", "43415.313777875"},
            {"KGS", "34731.0366221"},
            {"KHR", "1528326.2587398"},
            {"KMF", "167978.25919095"},
            {"KRW", "459456.86475"},
            {"KWD", "114.68473055"},
            {"KYD", "314.4754106"},
            {"KZT", "179458.646852875"},
            {"LAK", "4440410.8976591"},
            {"LBP", "570578.13755085"},
            {"LKR", "112245.8156729"},
            {"LRD", "57499.4327232"},
            {"LSL", "5509.47530835"},
            {"LYD", "1751.96589945"},
            {"MAD", "3663.231799825"},
            {"MDL", "6913.24359115"},
            {"MGA", "1524539.474526575"},
            {"MKD", "21008.790102625"},
            {"MMK", "671004.021676625"},
            {"MNT", "1091510.5070883"},
            {"MOP", "3045.669370575"},
            {"MRO", "134472.9102119"},
            {"MUR", "16830.217558375"},
            {"MVR", "5823.3955"},
            {"MWK", "308286.924739625"},
            {"MXN", "7480.5771625"},
            {"MYR", "1585.9900875"},
            {"MZN", "24050.698373325"},
            {"NAD", "5525.82225"},
            {"NGN", "157169.4246694"},
            {"NIO", "13505.772527"},
            {"NOK", "3280.652795875"},
            {"NPR", "45860.9843211"},
            {"NZD", "543.494187275"},
            {"OMR", "145.150581225"},
            {"PAB", "376.675"},
            {"PEN", "1387.94717945"},
            {"PGK", "1329.914745575"},
            {"PHP", "19410.06501005"},
            {"PKR", "69604.12266015"},
            {"PLN", "1581.89864365"},
            {"PYG", "2613768.091998375"},
            {"QAR", "1378.8775988"},
            {"RON", "1686.9389875"},
            {"RSD", "40161.0885"},
            {"RUB", "32299.88049665"},
            {"RWF", "383780.604356825"},
            {"SAR", "1413.04428135"},
            {"SBD", "3021.873304125"},
            {"SCR", "5433.678128125"},
            {"SEK", "3531.088936375"},
            {"SHP", "287.220337625"},
            {"SKK", "6203474.9670619239787"},
            {"SLL", "4435536.52653475"},
            {"SOS", "218288.0909157"},
            {"SRD", "7806.96605"},
            {"SSP", "49065.6855"},
            {"STD", "8077132.6168442"},
            {"SVC", "3301.94133685"},
            {"SZL", "5509.47530835"},
            {"THB", "12632.5509817"},
            {"TJS", "4894.367670075"},
            {"TMT", "1318.3625"},
            {"TND", "1106.294475"},
            {"TOP", "847.931962475"},
            {"TRY", "5532.0373875"},
            {"TTD", "2563.300872275"},
            {"TWD", "10803.6793475"},
            {"TZS", "875667.386477"},
            {"UAH", "11094.40690605"},
            {"UGX", "1349078.221426325"},
            {"UYU", "15528.80581005"},
            {"UZS", "4303653.736455125"},
            {"VES", "1647.953125"},
            {"VND", "8602880.325"},
            {"VUV", "42620.13665585"},
            {"WST", "980.7366439"},
            {"XAF", "223705.419088775"},
            {"XAG", "15.299574212"},
            {"XAU", "0.1956977295"},
            {"XCD", "1017.98302125"},
            {"XDR", "270.52723165"},
            {"XOF", "223705.419088775"},
            {"XPD", "0.16524355575"},
            {"XPF", "40696.505268575"},
            {"XPT", "0.380697889"},
            {"XTS", "2629.5794334391610702375"},
            {"YER", "94262.895019475"},
            {"ZAR", "5523.938875"},
            {"ZMW", "6764.172576525"},
            {"JEP", "287.220337625"},
            {"GGP", "287.220337625"},
            {"IMP", "287.220337625"},
            {"GBX", "24437.6914288531820835"},
            {"CNH", "2395.0126525"},
            {"TMM", "84685.65082105793352025"},
            {"ZWL", "121289.35"},
            {"SGD", "511.07264"},
            {"USD", "376.675"},
            {"BTC", "0.008129"},
            {"BCH", "1.0"},
            {"BSV", "3.774887766017554641"},
            {"ETH", "0.1079311910898564711355"},
            {"ETH2", "0.1079311910898564711355"},
            {"ETC", "8.136407819418943287275"},
            {"LTC", "2.960350518704810244"},
            {"ZRX", "431.93083143889982979"},
            {"USDC", "376.675"},
            {"BAT", "404.3746645195920963625"},
            {"LOOM", "3548.13185571040347905"},
            {"MANA", "139.910335554515522958"},
            {"KNC", "116.1430069067587605"},
            {"LINK", "21.0022302759966567988"},
            {"DNT", "2896.3860053825453173625"},
            {"MKR", "0.167728303970397352455"},
            {"CVC", "1003.5300386306113738625"},
            {"OMG", "63.62753378378378042425"},
            {"GNT", "1062.158888874789826835"},
            {"DAI", "376.6589919928403277775"},
            {"SNT", "4953.968567107253038475"},
            {"ZEC", "2.14373114791417662015"},
            {"XRP", "447.9772070433921869725"},
            {"REP", "22.56214435459718270225"},
            {"XLM", "1616.39850064475716427"},
            {"EOS", "134.286987522281641567"},
            {"XTZ", "95.00000000000000218975"},
            {"ALGO", "407.76725304465492667"},
            {"DASH", "2.854030913774814472725"},
            {"ATOM", "11.60249499460957828845"},
            {"OXT", "1246.4427531436134502625"},
            {"COMP", "2.26605504587155992025"},
            {"ENJ", "201.43048128342243975"},
            {"REPV2", "22.56214435459718270225"},
            {"BAND", "69.638565354039569537"},
            {"NMR", "12.22772277227722643825"},
            {"CGLD", "104.197786998616852775"},
            {"UMA", "45.964002440512507884"},
            {"LRC", "321.2579957356076660275"},
            {"YFI", "0.01570581518570013161355"},
            {"UNI", "31.9622401357658011275"},
            {"BAL", "23.4834788029925194735"},
            {"REN", "810.66394060045202614"},
            {"WBTC", "0.0081248808257342220365"},
            {"NU", "782.294911734164055045"},
            {"YFII", "0.161842645166418541065"},
            {"FIL", "14.9711844197138320175"},
            {"AAVE", "1.554966149273447731275"},
            {"BNT", "136.2296564195298337775"},
            {"GRT", "738.144228884969666825"},
            {"SNX", "52.79997196523689718975"},
            {"STORJ", "266.2014134275618317325"},
            {"SUSHI", "85.5107832009080575445"},
            {"MATIC", "223.9513659740182737275"},
            {"SKL", "1444.305981595092214495"},
            {"ADA", "319.8802598615769500875"},
            {"ANKR", "3913.099937668813815625"},
            {"CRV", "127.29807367353835903625"},
            {"ICP", "17.41447064262598493775"},
            {"NKN", "1267.19932716568535175"},
            {"OGN", "622.6033057851239765925"},
            {"1INCH", "191.789714867617095515"},
            {"USDT", "376.58085478630338449"},
            {"FORTH", "47.9230279898218830475"},
            {"CTSI", "760.65226171243955789"},
            {"TRB", "13.2889398482977590935"},
            {"POLY", "697.8047424972212740775"},
            {"MIR", "223.6123478777085332825"},
            {"RLC", "148.29724409448817648975"},
            {"DOT", "16.35584020842379477025"},
            {"SOL", "2.784821824634038393425"},
            {"DOGE", "2585.27796842827756595"},
            {"MLN", "5.950631911532386268775"},
            {"GTC", "46.07645259938837248925"},
            {"AMP", "13488.8093106535366598"},
            {"SHIB", "14099756.69099756602155"},
            {"CHZ", "1335.49016131891496565"},
            {"KEEP", "531.613859290099475825"},
            {"LPT", "12.96420581655480904675"},
            {"QNT", "2.6936141304347822846"},
            {"BOND", "40.39410187667560532775"},
            {"RLY", "1782.23326236101246555"},
            {"CLV", "749.229239184485266285"},
            {"FARM", "3.34406072443181852425"},
            {"MASK", "62.57059800664451856025"},
            {"FET", "811.100344530577127325"},
            {"PAX", "378.567839195979860505"},
            {"ACH", "8820.6022855001880231"},
            {"ASM", "6754.684838160136362225"},
            {"PLA", "326.6345820326049329375"},
            {"RAI", "124.93366500829186928475"},
            {"TRIBE", "607.295445384925490895"},
            {"ORN", "99.1249999999999980175"},
            {"IOTX", "3233.539359601682722825"},
            {"UST", "376.4867566216891671875"},
            {"QUICK", "1.5896478234263889513875"},
            {"AXS", "5.69038447012614288905"},
            {"REQ", "1433.314307458143307925"},
            {"WLUNA", "3.316092965930099745975"},
            {"TRU", "1572.42746816948439985"},
            {"RAD", "62.98913043478260928775"},
            {"COTI", "1342.1521468020665679875"},
            {"DDX", "128.558020477815680375"},
            {"SUKU", "1267.8391114102996451"},
            {"RGT", "22.650330727600723472"},
            {"XYO", "16470.26672496720409375"},
            {"ZEN", "7.687244897959182751"},
            {"AUCTION", "23.0382262996941866213"},
            {"JASMY", "12562.114390528595984"},
            {"WCFG", "552.3093841642227907225"},
            {"BTRST", "105.62955692652832652625"},
            {"AGLD", "218.806273598605858815"},
            {"AVAX", "3.867895466447604505225"},
            {"FX", "628.4725118878785361575"},
            {"TRAC", "515.181563290706469885"},
            {"LCX", "2812.0567375886522590625"},
            {"ARPA", "4215.72467823167315525"},
            {"BADGER", "32.8543392935019647385"},
            {"KRL", "409.206952743074407935"},
            {"PERP", "72.5770712909441138355"},
            {"RARI", "40.80985915492957970525"},
            {"DESO", "8.8807025816338559106"},
            {"API3", "70.0660342261904679395"},
            {"NCT", "8902.741668636256571"},
            {"SHPING", "16206.30310852963269925"},
            {"UPI", "5590.3086969427135204"},
            {"CRO", "784.0861781848459154375"},
            {"AVT", "150.06972111553786296725"},
            {"MDT", "6053.4351145038164888"},
            {"VGX", "209.438420906310794315"},
            {"ALCX", "3.0131589472842171392"},
            {"COVAL", "8156.6695539194463"},
            {"FOX", "1182.28185812931563395"},
            {"MUSD", "376.957718288716596265"},
            {"GALA", "1437.6908396946563784225"},
            {"POWR", "603.4040849018823166825"},
            {"GYEN", "46254.681647940074985"},
            {"ALICE", "46.54906080079090345575"},
            {"INV", "1.105867328215140231975"},
            {"LQTY", "128.3390119250425859855"},
            {"PRO", "233.2352941176470652375"},
            {"SPELL", "64943.965517241380869"},
            {"ENS", "18.8904212637913716515"},
            {"DIA", "334.82222222222218874"},
            {"BLZ", "1753.199906911798697625"},
            {"CTX", "51.14392396469789841525"},
            {"ERN", "62.57059800664451856025"},
            {"IDEX", "1862.88328387734899755"},
            {"MCO2", "36.028216164514583087"},
            {"POLS", "199.8275862068965710075"},
            {"SUPER", "445.76923076923080935"},
            {"UNFI", "54.1588785046728949595"},
            {"STX", "248.6303630363036431675"},
            {"GODS", "234.68847352024920898"},
            {"IMX", "145.3221450617283916205"},
            {"RBN", "260.674740484429035245"},
            {"BICO", "196.9542483660130898675"},
            {"GFI", "112.94602698650675015625"},
            {"GLM", "665.7976137870084447875"},
            {"MPL", "7.7092713876381502247"},
            {"PLU", "40.92069527430744456025"},
            {"FIDA", "182.409200968523005048"},
            {"ORCA", "160.628997867803829247"},
            {"CRPT", "620.29641827912725304"},
            {"QSP", "5420.9541627689423794"},
            {"RNDR", "122.4959349593495840025"},
            {"SYN", "113.03075768942235477225"},
            {"AIOZ", "1503.9928129367138196225"},
            {"AERGO", "1315.4356556661428011475"},
            {"HIGH", "52.82588878760255757175"},
            {"APE", "30.380691212646690175"},
            {"MINA", "140.02788104089220059"}
        };
        Assert.IsTrue(info != null, "Info is not empty");
        var rates = info.FirstOrDefault(a => a.Key == "USD");
        Assert.IsTrue(rates.Value != null, "Rates is not empty");
        Console.WriteLine($"Hash, {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetUsdPriceAsyncTest()
    {
        var info = await _priceService!.GetBchUsdPriceAsync();
        Assert.IsTrue(info > 0, "Info is not empty");
        Console.WriteLine($"Value, {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GeteCashUsdPriceAsyncTest()
    {
        var info = await _priceService!.GeteCashUsdPriceAsync();
        Assert.IsTrue(info > 0, "Info is not empty");
        Console.WriteLine($"Value, {info.ToJsonFormat()}");
    }
}