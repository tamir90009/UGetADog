using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGetADog.Models
{
   
    public class Giver
    {
        [key]
        public int GiverID { get; set; }

        public int UID { get; set; }
        [ForeignKey("UID")]
        public virtual User UserID { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

    
        public Double Rating { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public String Address { get; set; }
        public Double Latitude { get; set; }
        public Double Longtitude { get; set; }

        public List<Dog> Dogs{ get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
    /*
    public enum GiverAddress
    {
        [Display(Name = "אבו ג'ווייעד")]
        ABU_JUWEIID,
        [Display(Name = "אבו גוש")]
        ABU_GHOSH,
        [Display(Name = "אבו סנאן")]
        ABU_SINAN,
        [Display(Name = "אבו סריחאן")]
        ABU_SUREIHAN,
        [Display(Name = "אבו עבדון")]
        ABUABDUN,
        [Display(Name = "אבו עמאר")]
        ABUAMMAR,
        [Display(Name = "אבו עמרה")]
        ABUAMRE,
        [Display(Name = "אבו קורינאת")]
        ABU_QUREINAT,
        [Display(Name = "אבו רובייעה")]
        ABU_RUBEIA,
        [Display(Name = "אבו רוקייק")]
        ABU_RUQAYYEQ,
        [Display(Name = "אבו תלול")]
        ABU_TULUL,
        [Display(Name = "אבטין")]
        IBTIN,
        [Display(Name = "אבטליון")]
        AVTALYON,
        [Display(Name = "אביאל")]
        AVIEL,
        [Display(Name = "אביבים")]
        AVIVIM,
        [Display(Name = "אביגדור")]
        AVIGEDOR,
        [Display(Name = "אביחיל")]
        AVIHAYIL,
        [Display(Name = "אביטל")]
        AVITAL,
        [Display(Name = "אביעזר")]
        AVIEZER,
        [Display(Name = "אבירים")]
        ABBIRIM,
        [Display(Name = "אבן יהודה")]
        EVEN_YEHUDA,
        [Display(Name = "אבן מנחם")]
        EVEN_MENAHEM,
        [Display(Name = "אבן ספיר")]
        EVEN_SAPPIR,
        [Display(Name = "אבן שמואל")]
        EVEN_SHEMUEL,
        [Display(Name = "אבני איתן")]
        AVNE_ETAN,
        [Display(Name = "אבני חפץ")]
        AVNE_HEFEZ,
        [Display(Name = "אבנת")]
        AVENAT,
        [Display(Name = "אבשלום")]
        AVSHALOM,
        [Display(Name = "אדורה")]
        ADORA,
        [Display(Name = "אדירים")]
        ADDIRIM,
        [Display(Name = "אדמית")]
        ADAMIT,
        [Display(Name = "אדרת")]
        ADDERET,
        [Display(Name = "אודים")]
        UDIM,
        [Display(Name = "אודם")]
        ODEM,
        [Display(Name = "אוהד")]
        OHAD,
        [Display(Name = "אום אל-פחם")]
        UMM_AL_FAHM,
        [Display(Name = "אום אל-קוטוף")]
        UMM_AL_QUTUF,
        [Display(Name = "אום בטין")]
        UMM_BATIN,
        [Display(Name = "אומן")]
        OMEN,
        [Display(Name = "אומץ")]
        OMEZ,
        [Display(Name = "אופקים")]
        OFAQIM,
        [Display(Name = "אור הגנוז")]
        OR_HAGANUZ,
        [Display(Name = "אור הנר")]
        OR_HANER,
        [Display(Name = "אור יהודה")]
        OR_YEHUDA,
        [Display(Name = "אור עקיבא")]
        OR_AQIVA,
        [Display(Name = "אורה")]
        ORA,
        [Display(Name = "אורות")]
        OROT,
        [Display(Name = "אורטל")]
        ORTAL,
        [Display(Name = "אורים")]
        URIM,
        [Display(Name = "אורנים")]
        ORANIM,
        [Display(Name = "אורנית")]
        ORANIT,
        [Display(Name = "אושה")]
        USHA,
        [Display(Name = "אזור")]
        AZOR,
        [Display(Name = "אחווה")]
        AHAWA,
        [Display(Name = "אחוזם")]
        AHUZZAM,
        [Display(Name = "אחוזת ברק")]
        AHUZZAT_BARAQ,
        [Display(Name = "אחיהוד")]
        AHIHUD,
        [Display(Name = "אחיטוב")]
        AHITUV,
        [Display(Name = "אחיסמך")]
        AHISAMAKH,
        [Display(Name = "אחיעזר")]
        AHIEZER,
        [Display(Name = "אטרש")]
        ATRASH,
        [Display(Name = "איבים")]
        IBBIM,
        [Display(Name = "אייל")]
        EYAL,
        [Display(Name = "איילת השחר")]
        AYYELET_HASHAHAR,
        [Display(Name = "אילון")]
        ELON,
        [Display(Name = "אילות")]
        ELOT,
        [Display(Name = "אילניה")]
        ILANIYYA,
        [Display(Name = "אילת")]
        ELAT,
        [Display(Name = "אירוס")]
        IRUS,
        [Display(Name = "איתמר")]
        ITAMAR,
        [Display(Name = "איתן")]
        ETAN,
        [Display(Name = "איתנים")]
        ETANIM,
        [Display(Name = "אכסאל")]
        IKSAL,
        [Display(Name = "אל סייד")]
        AL_SAYYID,
        [Display(Name = "אל-עזי")]
        AL_AZY,
        [Display(Name = "אל-עריאן")]
        AL_ARYAN,
        [Display(Name = "אל-רום")]
        EL_ROM,
        [Display(Name = "אלומה")]
        ALUMMA,
        [Display(Name = "אלומות")]
        ALUMMOT,
        [Display(Name = "אלון הגליל")]
        ALLON_HAGALIL,
        [Display(Name = "אלון מורה")]
        ELON_MORE,
        [Display(Name = "אלון שבות")]
        ALLON_SHEVUT,
        [Display(Name = "אלוני אבא")]
        ALLONE_ABBA,
        [Display(Name = "אלוני הבשן")]
        ALLONE_HABASHAN,
        [Display(Name = "אלוני יצחק")]
        ALLONE_YIZHAQ,
        [Display(Name = "אלונים")]
        ALLONIM,
        [Display(Name = "אלי-עד")]
        ELI_AL,
        [Display(Name = "אליאב")]
        ELIAV,
        [Display(Name = "אליכין")]
        ELYAKHIN,
        [Display(Name = "אליפז")]
        ELIFAZ,
        [Display(Name = "אליפלט")]
        ELIFELET,
        [Display(Name = "אליקים")]
        ELYAQIM,
        [Display(Name = "אלישיב")]
        ELYASHIV,
        [Display(Name = "אלישמע")]
        ELISHAMA,
        [Display(Name = "אלמגור")]
        ALMAGOR,
        [Display(Name = "אלמוג")]
        ALMOG,
        [Display(Name = "אלעד")]
        ELAD,
        [Display(Name = "אלעזר")]
        ELAZAR,
        [Display(Name = "אלפי מנשה")]
        ALFE_MENASHE,
        [Display(Name = "אלקוש")]
        ELQOSH,
        [Display(Name = "אלקנה")]
        ELQANA,
        [Display(Name = "אמונים")]
        EMUNIM,
        [Display(Name = "אמירים")]
        AMIRIM,
        [Display(Name = "אמנון")]
        AMNUN,
        [Display(Name = "אמציה")]
        AMAZYA,
        [Display(Name = "אניעם")]
        ANIAM,
        [Display(Name = "אסד")]
        ASAD,
        [Display(Name = "אספר")]
        ASEFAR,
        [Display(Name = "אעבלין")]
        IBILLIN,
        [Display(Name = "אעצם")]
        ASAM,
        [Display(Name = "אפיניש")]
        AFEINISH,
        [Display(Name = "אפיק")]
        AFIQ,
        [Display(Name = "אפיקים")]
        AFIQIM,
        [Display(Name = "אפק")]
        AFEQ,
        [Display(Name = "אפרת")]
        EFRAT,
        [Display(Name = "ארבל")]
        ARBEL,
        [Display(Name = "ארגמן")]
        ARGAMAN,
        [Display(Name = "ארז")]
        EREZ,
        [Display(Name = "אריאל")]
        ARIEL,
        [Display(Name = "ארסוף")]
        ARSUF,
        [Display(Name = "אשבול")]
        ESHBOL,
        [Display(Name = "אשבל")]
        NAHAL_ESHBAL,
        [Display(Name = "אשדוד")]
        ASHDOD,
        [Display(Name = "אשדות יעקב")]
        ASHDOT_YAAQOV,
        [Display(Name = "אשחר")]
        ESHHAR,
        [Display(Name = "אשכולות")]
        ESHKOLOT,
        [Display(Name = "אשל הנשיא")]
        ESHEL_HANASI,
        [Display(Name = "אשלים")]
        ASHALIM,
        [Display(Name = "אשקלון")]
        ASHQELON,
        [Display(Name = "אשרת")]
        ASHERAT,
        [Display(Name = "אשתאול")]
        ESHTAOL,
        [Display(Name = "אתגר")]
        ETGAR,
        [Display(Name = "באקה אל-גרביה")]
        BAQA_AL_GHARBIYYE,
        [Display(Name = "באר אורה")]
        BEER_ORA,
        [Display(Name = "באר גנים")]
        BEER_GANNIM,
        [Display(Name = "באר טוביה")]
        BEER_TUVEYA,
        [Display(Name = "באר יעקב")]
        BEER_YAAQOV,
        [Display(Name = "באר מילכה")]
        BEER_MILKA,
        [Display(Name = "באר שבע")]
        BEER_SHEVA,
        [Display(Name = "בארות יצחק")]
        BEEROT_YIZHAQ,
        [Display(Name = "בארותיים")]
        BEEROTAYIM,
        [Display(Name = "בארי")]
        BEERI,
        [Display(Name = "בוסתן הגליל")]
        BUSTAN_HAGALIL,
        [Display(Name = "בועיינה-נוג'ידאת")]
        BUEINE_NUJEIDAT,
        [Display(Name = "בוקעאתא")]
        BUQATA,
        [Display(Name = "בורגתה")]
        BURGETA,
        [Display(Name = "בחן")]
        BAHAN,
        [Display(Name = "בטחה")]
        BITHA,
        [Display(Name = "ביצרון")]
        BIZZARON,
        [Display(Name = "ביר אל-מכסור")]
        BIR_EL_MAKSUR,
        [Display(Name = "ביר הדאג'")]
        BIR_HADAGE,
        [Display(Name = "ביריה")]
        BIRIYYA,
        [Display(Name = "בית אורן")]
        BET_OREN,
        [Display(Name = "בית אל")]
        BET_EL,
        [Display(Name = "בית אלעזרי")]
        BET_ELAZARI,
        [Display(Name = "בית אלפא")]
        BET_ALFA,
        [Display(Name = "בית אריה")]
        BET_ARYE,
        [Display(Name = "בית ברל")]
        BET_BERL,
        [Display(Name = "בית ג'ן")]
        BEIT_JANN,
        [Display(Name = "בית גוברין")]
        BET_GUVRIN,
        [Display(Name = "בית גמליאל")]
        BET_GAMLIEL,
        [Display(Name = "בית דגן")]
        BET_DAGAN,
        [Display(Name = "בית הגדי")]
        BET_HAGADDI,
        [Display(Name = "בית הלוי")]
        BET_HALEVI,
        [Display(Name = "בית הלל")]
        BET_HILLEL,
        [Display(Name = "בית העמק")]
        BET_HAEMEQ,
        [Display(Name = "בית הערבה")]
        BET_HAARAVA,
        [Display(Name = "בית השיטה")]
        BET_HASHITTA,
        [Display(Name = "בית זיד")]
        BET_ZEID,
        [Display(Name = "בית זית")]
        BET_ZAYIT,
        [Display(Name = "בית זרע")]
        BET_ZERA,
        [Display(Name = "בית חורון")]
        BET_HORON,
        [Display(Name = "בית חירות")]
        BET_HERUT,
        [Display(Name = "בית חלקיה")]
        BET_HILQIYYA,
        [Display(Name = "בית חנן")]
        BET_HANAN,
        [Display(Name = "בית חנניה")]
        BET_HANANYA,
        [Display(Name = "בית חשמונאי")]
        BET_HASHMONAY,
        [Display(Name = "בית יהושע")]
        BET_YEHOSHUA,
        [Display(Name = "בית יוסף")]
        BET_YOSEF,
        [Display(Name = "בית ינאי")]
        BET_YANNAY,
        [Display(Name = "בית יצחק-שער חפר")]
        BET_YIZHAQ_SH_HEFER,
        [Display(Name = "בית לחם הגלילית")]
        BET_LEHEM_HAGELILIT,
        [Display(Name = "בית מאיר")]
        BET_MEIR,
        [Display(Name = "בית נחמיה")]
        BET_NEHEMYA,
        [Display(Name = "בית ניר")]
        BET_NIR,
        [Display(Name = "בית נקופה")]
        BET_NEQOFA,
        [Display(Name = "בית עובד")]
        BET_OVED,
        [Display(Name = "בית עוזיאל")]
        BET_UZZIEL,
        [Display(Name = "בית עזרא")]
        BET_EZRA,
        [Display(Name = "בית עריף")]
        BET_ARIF,
        [Display(Name = "בית צבי")]
        BET_ZEVI,
        [Display(Name = "בית קמה")]
        BET_QAMA,
        [Display(Name = "בית קשת")]
        BET_QESHET,
        [Display(Name = "בית רבן")]
        BET_RABBAN,
        [Display(Name = "בית רימון")]
        BET_RIMMON,
        [Display(Name = "בית שאן")]
        BET_SHEAN,
        [Display(Name = "בית שמש")]
        BET_SHEMESH,
        [Display(Name = "בית שערים")]
        BET_SHEARIM,
        [Display(Name = "בית שקמה")]
        BET_SHIQMA,
        [Display(Name = "ביתן אהרן")]
        BITAN_AHARON,
        [Display(Name = "ביתר עילית")]
        BETAR_ILLIT,
        [Display(Name = "בלפוריה")]
        BALFURIYYA,
        [Display(Name = "בן זכאי")]
        BEN_ZAKKAY,
        [Display(Name = "בן עמי")]
        BEN_AMMI,
        [Display(Name = "בן שמן")]
        BEN_SHEMEN,
        [Display(Name = "בני ברק")]
        BENE_BERAQ,
        [Display(Name = "בני דקלים")]
        BNE_DKALIM,
        [Display(Name = "בני דרום")]
        BENE_DAROM,
        [Display(Name = "בני דרור")]
        BENE_DEROR,
        [Display(Name = "בני יהודה")]
        BENE_YEHUDA,
        [Display(Name = "בני נצרים")]
        BENE_NEZARIM,
        [Display(Name = "בני עטרות")]
        BENE_ATAROT,
        [Display(Name = "בני עי\"ש")]
        BENE_AYISH,
        [Display(Name = "בני ציון")]
        BENE_ZIYYON,
        [Display(Name = "בני ראם")]
        BENE_REEM,
        [Display(Name = "בניה")]
        BENAYA,
        [Display(Name = "בנימינה-גבעת עדה")]
        BINYAMINA,
        [Display(Name = "בסמ\"ה")]
        BASMA,
        [Display(Name = "בסמת טבעון")]
        BASMAT_TABUN,
        [Display(Name = "בענה")]
        BI_NE,
        [Display(Name = "בצרה")]
        BAZRA,
        [Display(Name = "בצת")]
        BEZET,
        [Display(Name = "בקוע")]
        BEQOA,
        [Display(Name = "בקעות")]
        BEQAOT,
        [Display(Name = "בר גיורא")]
        BAR_GIYYORA,
        [Display(Name = "בר יוחאי")]
        BAR_YOHAY,
        [Display(Name = "ברוכין")]
        BRUKHIN,
        [Display(Name = "ברור חיל")]
        BEROR_HAYIL,
        [Display(Name = "ברוש")]
        BEROSH,
        [Display(Name = "ברכה")]
        BERAKHA,
        [Display(Name = "ברכיה")]
        BEREKHYA,
        [Display(Name = "ברעם")]
        BARAM,
        [Display(Name = "ברק")]
        BARAQ,
        [Display(Name = "ברקאי")]
        BARQAY,
        [Display(Name = "ברקן")]
        BARQAN,
        [Display(Name = "ברקת")]
        BAREQET,
        [Display(Name = "בת הדר")]
        BAT_HADAR,
        [Display(Name = "בת חן")]
        BAT_HEN,
        [Display(Name = "בת חפר")]
        BAT_HEFER,
        [Display(Name = "בת חצור")]
        BAT_HAZOR,
        [Display(Name = "בת ים")]
        BAT_YAM,
        [Display(Name = "בת עין")]
        BAT_AYIN,
        [Display(Name = "בת שלמה")]
        BAT_SHELOMO,
        [Display(Name = "ג'דיידה-מכר")]
        JUDEIDE_MAKER,
        [Display(Name = "ג'ולס")]
        JULIS,
        [Display(Name = "ג'לג'וליה")]
        JALJULYE,
        [Display(Name = "ג'נאביב")]
        JUNNABIB,
        [Display(Name = "ג'סר א-זרקא")]
        JISR_AZ_ZARQA,
        [Display(Name = "ג'ש )גוש חלב(")]
        JISH,
        [Display(Name = "ג'ת")]
        JAAT,
        [Display(Name = "גאולי תימן")]
        GEULE_TEMAN,
        [Display(Name = "גאולים")]
        GEULIM,
        [Display(Name = "גאליה")]
        GEALYA,
        [Display(Name = "גבולות")]
        GEVULOT,
        [Display(Name = "גבים")]
        GEVIM,
        [Display(Name = "גבע")]
        GEVA,
        [Display(Name = "גבע בנימין")]
        GEVA_BINYAMIN,
        [Display(Name = "גבע כרמל")]
        GEVAKARMEL,
        [Display(Name = "גבעולים")]
        GIVOLIM,
        [Display(Name = "גבעון החדשה")]
        GIVON_HAHADASHA,
        [Display(Name = "גבעות בר")]
        GEVAOT_BAR,
        [Display(Name = "גבעת אבני")]
        GIVAT_AVNI,
        [Display(Name = "גבעת אלה")]
        GIVAT_ELA,
        [Display(Name = "גבעת ברנר")]
        GIVAT_BRENNER,
        [Display(Name = "גבעת השלושה")]
        GIVAT_HASHELOSHA,
        [Display(Name = "גבעת זאב")]
        GIVAT_ZEEV,
        [Display(Name = "גבעת ח\"ן")]
        GIVAT_HEN,
        [Display(Name = "גבעת חיים")]
        GIVAT_HAYYIM,
        [Display(Name = "גבעת יואב")]
        GIVAT_YOAV,
        [Display(Name = "גבעת יערים")]
        GIVAT_YEARIM,
        [Display(Name = "גבעת ישעיהו")]
        GIVAT_YESHAYAHU,
        [Display(Name = "גבעת כ\"ח")]
        GIVAT_KOAH,
        [Display(Name = "גבעת ניל\"י")]
        GIVAT_NILI,
        [Display(Name = "גבעת עוז")]
        GIVAT_OZ,
        [Display(Name = "גבעת שמואל")]
        GIVAT_SHEMUEL,
        [Display(Name = "גבעת שמש")]
        GIVAT_SHEMESH,
        [Display(Name = "גבעת שפירא")]
        GIVAT_SHAPPIRA,
        [Display(Name = "גבעתי")]
        GIVATI,
        [Display(Name = "גבעתיים")]
        GIVATAYIM,
        [Display(Name = "גברעם")]
        GEVARAM,
        [Display(Name = "גבת")]
        GEVAT,
        [Display(Name = "גדות")]
        GADOT,
        [Display(Name = "גדיש")]
        GADISH,
        [Display(Name = "גדעונה")]
        GIDONA,
        [Display(Name = "גדרה")]
        GEDERA,
        [Display(Name = "גונן")]
        GONEN,
        [Display(Name = "גורן")]
        GOREN,
        [Display(Name = "גורנות הגליל")]
        GORNOT_HAGALIL,
        [Display(Name = "גזית")]
        GAZIT,
        [Display(Name = "גזר")]
        GEZER,
        [Display(Name = "גיאה")]
        GEA,
        [Display(Name = "גיבתון")]
        GIBBETON,
        [Display(Name = "גיזו")]
        GIZO,
        [Display(Name = "גילון")]
        GILON,
        [Display(Name = "גילת")]
        GILAT,
        [Display(Name = "גינוסר")]
        GINNOSAR,
        [Display(Name = "גיניגר")]
        GINNEGAR,
        [Display(Name = "גינתון")]
        GINNATON,
        [Display(Name = "גיתה")]
        GITTA,
        [Display(Name = "גיתית")]
        GITTIT,
        [Display(Name = "גלאון")]
        GALON,
        [Display(Name = "גלגל")]
        GILGAL,
        [Display(Name = "גליל ים")]
        GELIL_YAM,
        [Display(Name = "גלעד )אבן יצחק(")]
        EVEN_YIZHAQ,
        [Display(Name = "גמזו")]
        GIMZO,
        [Display(Name = "גן הדרום")]
        GAN_HADAROM,
        [Display(Name = "גן השומרון")]
        GAN_HASHOMERON,
        [Display(Name = "גן חיים")]
        GAN_HAYYIM,
        [Display(Name = "גן יאשיה")]
        GAN_YOSHIYYA,
        [Display(Name = "גן יבנה")]
        GAN_YAVNE,
        [Display(Name = "גן נר")]
        GAN_NER,
        [Display(Name = "גן שורק")]
        GAN_SOREQ,
        [Display(Name = "גן שלמה")]
        GAN_SHELOMO,
        [Display(Name = "גן שמואל")]
        GAN_SHEMUEL,
        [Display(Name = "גנות")]
        GANNOT,
        [Display(Name = "גנות הדר")]
        GANNOT_HADAR,
        [Display(Name = "גני הדר")]
        GANNE_HADAR,
        [Display(Name = "גני טל")]
        GANNE_TAL,
        [Display(Name = "גני יוחנן")]
        GANNE_YOHANAN,
        [Display(Name = "גני מודיעין")]
        GANNE_MODIIN,
        [Display(Name = "גני עם")]
        GANNE_AM,
        [Display(Name = "גני תקווה")]
        GANNE_TIQWA,
        [Display(Name = "געש")]
        GAASH,
        [Display(Name = "געתון")]
        GATON,
        [Display(Name = "גפן")]
        GEFEN,
        [Display(Name = "גרופית")]
        GEROFIT,
        [Display(Name = "גשור")]
        GESHUR,
        [Display(Name = "גשר")]
        GESHER,
        [Display(Name = "גשר הזיו")]
        GESHER_HAZIW,
        [Display(Name = "גת )קיבוץ(")]
        GAT,
        [Display(Name = "גת רימון")]
        GAT_RIMMON,
        [Display(Name = "דאלית אל-כרמל")]
        DALIYAT_AL_KARMEL,
        [Display(Name = "דבורה")]
        DEVORA,
        [Display(Name = "דבוריה")]
        DABBURYE,
        [Display(Name = "דבירה")]
        DEVIRA,
        [Display(Name = "דברת")]
        DAVERAT,
        [Display(Name = "דגניה א'")]
        DEGANYA_ALEF,
        [Display(Name = "דגניה ב'")]
        DEGANYA_BET,
        [Display(Name = "דוב\"ב")]
        DOVEV,
        [Display(Name = "דולב")]
        DOLEV,
        [Display(Name = "דור")]
        DOR,
        [Display(Name = "דורות")]
        DOROT,
        [Display(Name = "דחי")]
        DAHI,
        [Display(Name = "דייר אל-אסד")]
        DEIR_AL_ASAD,
        [Display(Name = "דייר חנא")]
        DEIR_HANNA,
        [Display(Name = "דייר ראפאת")]
        DEIR_RAFAT,
        [Display(Name = "דימונה")]
        DIMONA,
        [Display(Name = "דישון")]
        DISHON,
        [Display(Name = "דליה")]
        DALIYYA,
        [Display(Name = "דלתון")]
        DALTON,
        [Display(Name = "דמיידה")]
        DEMEIDE,
        [Display(Name = "דן")]
        DAN,
        [Display(Name = "דפנה")]
        DAFNA,
        [Display(Name = "דקל")]
        DEQEL,
        [Display(Name = "דריג'את")]
        DERIGAT,
        [Display(Name = "האון")]
        HAON,
        [Display(Name = "הבונים")]
        HABONIM,
        [Display(Name = "הגושרים")]
        HAGOSHERIM,
        [Display(Name = "הדר עם")]
        HADAR_AM,
        [Display(Name = "הוד השרון")]
        HOD_HASHARON,
        [Display(Name = "הודיה")]
        HODIYYA,
        [Display(Name = "הודיות")]
        HODAYOT,
        [Display(Name = "הוואשלה")]
        HAWASHLA,
        [Display(Name = "הוזייל")]
        HUZAYYEL,
        [Display(Name = "הושעיה")]
        HOSHAAYA,
        [Display(Name = "הזורע")]
        HAZOREA,
        [Display(Name = "הזורעים")]
        HAZOREIM,
        [Display(Name = "החותרים")]
        HAHOTERIM,
        [Display(Name = "היוגב")]
        HAYOGEV,
        [Display(Name = "הילה")]
        HILLA,
        [Display(Name = "המעפיל")]
        HAMAPIL,
        [Display(Name = "הסוללים")]
        HASOLELIM,
        [Display(Name = "העוגן")]
        HAOGEN,
        [Display(Name = "הר אדר")]
        HAR_ADAR,
        [Display(Name = "הר גילה")]
        HAR_GILLO,
        [Display(Name = "הר עמשא")]
        HAR_AMASA,
        [Display(Name = "הראל")]
        HAREL,
        [Display(Name = "הרדוף")]
        HARDUF,
        [Display(Name = "הרצליה")]
        HERZELIYYA,
        [Display(Name = "הררית")]
        HARARIT,
        [Display(Name = "ורד יריחו")]
        WERED_YERIHO,
        [Display(Name = "ורדון")]
        WARDON,
        [Display(Name = "זבארגה")]
        ZABARGA,
        [Display(Name = "זבדיאל")]
        ZAVDIEL,
        [Display(Name = "זוהר")]
        ZOHAR,
        [Display(Name = "זיקים")]
        ZIQIM,
        [Display(Name = "זיתן")]
        ZETAN,
        [Display(Name = "זכרון יעקב")]
        ZIKHRON_YAAQOV,
        [Display(Name = "זכריה")]
        ZEKHARYA,
        [Display(Name = "זמר")]
        ZEMER,
        [Display(Name = "זמרת")]
        ZIMRAT,
        [Display(Name = "זנוח")]
        ZANOAH,
        [Display(Name = "זרועה")]
        ZERUA,
        [Display(Name = "זרזיר")]
        ZARZIR,
        [Display(Name = "זרחיה")]
        ZERAHYA,
        [Display(Name = "ח'ואלד")]
        KHAWALED,
        [Display(Name = "חבצלת השרון")]
        HAVAZZELET_HASHARON,
        [Display(Name = "חבר")]
        HEVER,
        [Display(Name = "חברון")]
        hebron,
        [Display(Name = "חגור")]
        HAGOR,
        [Display(Name = "חגי")]
        HAGGAI,
        [Display(Name = "חגלה")]
        HOGLA,
        [Display(Name = "חד-נס")]
        HAD_NES,
        [Display(Name = "חדיד")]
        HADID,
        [Display(Name = "חדרה")]
        HADERA,
        [Display(Name = "חוג'ייראת )ד'הרה(")]
        HUJEIRAT,
        [Display(Name = "חולדה")]
        HULDA,
        [Display(Name = "חולון")]
        HOLON,
        [Display(Name = "חולית")]
        HOLIT,
        [Display(Name = "חולתה")]
        HULATA,
        [Display(Name = "חוסן")]
        HOSEN,
        [Display(Name = "חוסנייה")]
        HUSSNIYYA,
        [Display(Name = "חופית")]
        HOFIT,
        [Display(Name = "חוקוק")]
        HUQOQ,
        [Display(Name = "חורה")]
        HURA,
        [Display(Name = "חורפיש")]
        HURFEISH,
        [Display(Name = "חורשים")]
        HORESHIM,
        [Display(Name = "חזון")]
        HAZON,
        [Display(Name = "חיבת ציון")]
        HIBBAT_ZIYYON,
        [Display(Name = "חיננית")]
        HINNANIT,
        [Display(Name = "חיפה")]
        HAIFA,
        [Display(Name = "חירות")]
        HERUT,
        [Display(Name = "חלוץ")]
        HALUZ,
        [Display(Name = "חלמיש")]
        HALLAMISH,
        [Display(Name = "חלץ")]
        HELEZ,
        [Display(Name = "חמאם")]
        HAMAM,
        [Display(Name = "חמד")]
        HEMED,
        [Display(Name = "חמדיה")]
        HAMADYA,
        [Display(Name = "חמדת")]
        NAHAL_HEMDAT,
        [Display(Name = "חמרה")]
        HAMRA,
        [Display(Name = "חניאל")]
        HANNIEL,
        [Display(Name = "חניתה")]
        HANITA,
        [Display(Name = "חנתון")]
        HANNATON,
        [Display(Name = "חספין")]
        HASPIN,
        [Display(Name = "חפץ חיים")]
        HAFEZ_HAYYIM,
        [Display(Name = "חפצי-בה")]
        HEFZI_BAH,
        [Display(Name = "חצב")]
        HAZAV,
        [Display(Name = "חצבה")]
        HAZEVA,
        [Display(Name = "חצור הגלילית")]
        HAZOR_HAGELILIT,
        [Display(Name = "חצור-אשדוד")]
        HAZOR_ASHDOD,
        [Display(Name = "חצר בארותיים")]
        HAZAR_BEEROTAYIM,
        [Display(Name = "חצרות חולדה")]
        HAZROT_HULDA,
        [Display(Name = "חצרות יסף")]
        HAZROT_YASAF,
        [Display(Name = "חצרות כ\"ח")]
        HAZROT_KOAH,
        [Display(Name = "חצרים")]
        HAZERIM,
        [Display(Name = "חרב לאת")]
        HEREV_LEET,
        [Display(Name = "חרוצים")]
        HARUZIM,
        [Display(Name = "חריש")]
        HARISH,
        [Display(Name = "חרמש")]
        HERMESH,
        [Display(Name = "חרשים")]
        HARASHIM,
        [Display(Name = "חשמונאים")]
        HASHMONAIM,
        [Display(Name = "טבריה")]
        TIBERIAS,
        [Display(Name = "טובא-זנגריה")]
        TUBA_ZANGARIYYE,
        [Display(Name = "טורעאן")]
        TURAN,
        [Display(Name = "טייבה")]
        TAYIBE,
        [Display(Name = "טירה")]
        TIRE,
        [Display(Name = "טירת יהודה")]
        TIRAT_YEHUDA,
        [Display(Name = "טירת כרמל")]
        TIRAT_KARMEL,
        [Display(Name = "טירת צבי")]
        TIRAT_ZEVI,
        [Display(Name = "טל שחר")]
        TAL_SHAHAR,
        [Display(Name = "טל-אל")]
        TAL_EL,
        [Display(Name = "טללים")]
        TELALIM,
        [Display(Name = "טלמון")]
        TALMON,
        [Display(Name = "טמרה")]
        TAMRA,
        [Display(Name = "טנא")]
        TENE,
        [Display(Name = "טפחות")]
        TEFAHOT,
        [Display(Name = "יאנוח-ג'ת")]
        YANUH_JAT,
        [Display(Name = "יבול")]
        YEVUL,
        [Display(Name = "יבנאל")]
        YAVNEEL,
        [Display(Name = "יבנה")]
        YAVNE,
        [Display(Name = "יגור")]
        YAGUR,
        [Display(Name = "יגל")]
        YAGEL,
        [Display(Name = "יד בנימין")]
        YAD_BINYAMIN,
        [Display(Name = "יד השמונה")]
        YAD_HASHEMONA,
        [Display(Name = "יד חנה")]
        YAD_HANNA,
        [Display(Name = "יד מרדכי")]
        YAD_MORDEKHAY,
        [Display(Name = "יד נתן")]
        YAD_NATAN,
        [Display(Name = "יד רמב\"ם")]
        YAD_RAMBAM,
        [Display(Name = "ידידה")]
        YEDIDA,
        [Display(Name = "יהוד-מונוסון")]
        YEHUD_MONOSON,
        [Display(Name = "יהל")]
        YAHEL,
        [Display(Name = "יובל")]
        YUVAL,
        [Display(Name = "יובלים")]
        YUVALIM,
        [Display(Name = "יודפת")]
        YODEFAT,
        [Display(Name = "יונתן")]
        YONATAN,
        [Display(Name = "יושיביה")]
        YOSHIVYA,
        [Display(Name = "יזרעאל")]
        YIZREEL,
        [Display(Name = "יחיעם")]
        YEHIAM,
        [Display(Name = "יטבתה")]
        YOTVATA,
        [Display(Name = "ייט\"ב")]
        YITAV,
        [Display(Name = "יכיני")]
        YAKHINI,
        [Display(Name = "ינוב")]
        YANUV,
        [Display(Name = "ינון")]
        YINNON,
        [Display(Name = "יסוד המעלה")]
        YESUD_HAMAALA,
        [Display(Name = "יסודות")]
        YESODOT,
        [Display(Name = "יסעור")]
        YASUR,
        [Display(Name = "יעד")]
        YAAD,
        [Display(Name = "יעל")]
        YAEL,
        [Display(Name = "יעף")]
        YEAF,
        [Display(Name = "יערה")]
        YAARA,
        [Display(Name = "יפיע")]
        YAFI,
        [Display(Name = "יפית")]
        YAFIT,
        [Display(Name = "יפעת")]
        YIFAT,
        [Display(Name = "יפתח")]
        YIFTAH,
        [Display(Name = "יצהר")]
        YIZHAR,
        [Display(Name = "יציץ")]
        YAZIZ,
        [Display(Name = "יקום")]
        YAQUM,
        [Display(Name = "יקיר")]
        YAQIR,
        [Display(Name = "יקנעם")]
        YOQNEAM,
        [Display(Name = "יקנעם עילית")]
        YOQNEAM_ILLIT,
        [Display(Name = "יראון")]
        YIRON,
        [Display(Name = "ירדנה")]
        YARDENA,
        [Display(Name = "ירוחם")]
        YEROHAM,
        [Display(Name = "ירושלים")]
        JERUSALEM,
        [Display(Name = "ירחיב")]
        YARHIV,
        [Display(Name = "ירכא")]
        YIRKA,
        [Display(Name = "ירקונה")]
        YARQONA,
        [Display(Name = "ישע")]
        YESHA,
        [Display(Name = "ישעי")]
        YISHI,
        [Display(Name = "ישרש")]
        YASHRESH,
        [Display(Name = "יתד")]
        YATED,
        [Display(Name = "יתיר")]
        yatir,
        [Display(Name = "כאבול")]
        KABUL,
        [Display(Name = "כאוכב אבו אל-היג'א")]
        KAOKAB_ABU_AL_HIJA,
        [Display(Name = "כברי")]
        KABRI,
        [Display(Name = "כדורי")]
        KADOORIE,
        [Display(Name = "כדיתה")]
        KADDITA,
        [Display(Name = "כוכב השחר")]
        KOKHAV_HASHAHAR,
        [Display(Name = "כוכב יאיר")]
        KOKHAV_YAIR,
        [Display(Name = "כוכב יעקב")]
        KOKHAV_YAAQOV,
        [Display(Name = "כוכב מיכאל")]
        KOKHAV_MIKHAEL,
        [Display(Name = "כורזים")]
        KORAZIM,
        [Display(Name = "כחל")]
        KAHAL,
        [Display(Name = "כחלה")]
        KOCHLEA,
        [Display(Name = "כיסופים")]
        KISSUFIM,
        [Display(Name = "כישור")]
        KISHOR,
        [Display(Name = "כליל")]
        KELIL,
        [Display(Name = "כלנית")]
        KALLANIT,
        [Display(Name = "כמאנה")]
        Kamanneh,
        [Display(Name = "כמהין")]
        KEMEHIN,
        [Display(Name = "כמון")]
        KAMMON,
        [Display(Name = "כנות")]
        KANNOT,
        [Display(Name = "כנף")]
        KANAF,
        [Display(Name = "כנרת")]
        KINNERET,
        [Display(Name = "כסיפה")]
        KUSEIFE,
        [Display(Name = "כסלון")]
        KESALON,
        [Display(Name = "כסרא-סמיע")]
        KISRA_SUMEI,
        [Display(Name = "כעביה-טבאש-חג'אג'רה")]
        KAABIYYE_TABBASH_HA,
        [Display(Name = "כפר אביב")]
        KEFAR_AVIV,
        [Display(Name = "כפר אדומים")]
        KEFAR_ADUMMIM,
        [Display(Name = "כפר אוריה")]
        KEFAR_URIYYA,
        [Display(Name = "כפר אחים")]
        KEFAR_AHIM,
        [Display(Name = "כפר ביאליק")]
        KEFAR_BIALIK,
        [Display(Name = "כפר ביל\"ו")]
        KEFAR_BILU,
        [Display(Name = "כפר בלום")]
        KEFAR_BLUM,
        [Display(Name = "כפר בן נון")]
        KEFAR_BIN_NUN,
        [Display(Name = "כפר ברא")]
        KAFAR_BARA,
        [Display(Name = "כפר ברוך")]
        KEFAR_BARUKH,
        [Display(Name = "כפר גדעון")]
        KEFAR_GIDON,
        [Display(Name = "כפר גלים")]
        KEFAR_GALLIM,
        [Display(Name = "כפר גליקסון")]
        KEFAR_GLIKSON,
        [Display(Name = "כפר גלעדי")]
        KEFAR_GILADI,
        [Display(Name = "כפר דניאל")]
        KEFAR_DANIYYEL,
        [Display(Name = "כפר האורנים")]
        KEFAR_HAORANIM,
        [Display(Name = "כפר החורש")]
        KEFAR_HAHORESH,
        [Display(Name = "כפר המכבי")]
        KEFAR_HAMAKKABI,
        [Display(Name = "כפר הנגיד")]
        KEFAR_HANAGID,
        [Display(Name = "כפר הנוער הדתי")]
        KEFAR_HANOAR_HADATI,
        [Display(Name = "כפר הנשיא")]
        KEFAR_HANASI,
        [Display(Name = "כפר הס")]
        KEFAR_HESS,
        [Display(Name = "כפר הרא\"ה")]
        KEFAR_HAROE,
        [Display(Name = "כפר הרי\"ף")]
        KEFAR_HARIF,
        [Display(Name = "כפר ויתקין")]
        KEFAR_VITKIN,
        [Display(Name = "כפר ורבורג")]
        KEFAR_WARBURG,
        [Display(Name = "כפר ורדים")]
        KEFAR_WERADIM,
        [Display(Name = "כפר זוהרים")]
        KEFAR_ZOHARIM,
        [Display(Name = "כפר זיתים")]
        KEFAR_ZETIM,
        [Display(Name = "כפר חב\"ד")]
        KEFAR_HABAD,
        [Display(Name = "כפר חושן")]
        KEFAR_HOSHEN,
        [Display(Name = "כפר חיטים")]
        KEFAR_HITTIM,
        [Display(Name = "כפר חיים")]
        KEFAR_HAYYIM,
        [Display(Name = "כפר חנניה")]
        KEFAR_HANANYA,
        [Display(Name = "כפר חסידים א'")]
        KEFAR_HASIDIM_ALEF,
        [Display(Name = "כפר חסידים ב'")]
        KEFAR_HASIDIM_BET,
        [Display(Name = "כפר חרוב")]
        KEFAR_HARUV,
        [Display(Name = "כפר טרומן")]
        KEFAR_TRUMAN,
        [Display(Name = "כפר יאסיף")]
        KAFAR_YASIF,
        [Display(Name = "כפר ידידיה")]
        YEDIDYA,
        [Display(Name = "כפר יהושע")]
        KEFAR_YEHOSHUA,
        [Display(Name = "כפר יונה")]
        KEFAR_YONA,
        [Display(Name = "כפר יחזקאל")]
        KEFAR_YEHEZQEL,
        [Display(Name = "כפר יעבץ")]
        KEFAR_YABEZ,
        [Display(Name = "כפר כמא")]
        KAFAR_KAMA,
        [Display(Name = "כפר כנא")]
        KAFAR_KANNA,
        [Display(Name = "כפר מונש")]
        KEFAR_MONASH,
        [Display(Name = "כפר מימון")]
        KEFAR_MAYMON,
        [Display(Name = "כפר מל\"ל")]
        KEFAR_MALAL,
        [Display(Name = "כפר מנדא")]
        KAFAR_MANDA,
        [Display(Name = "כפר מנחם")]
        KEFAR_MENAHEM,
        [Display(Name = "כפר מסריק")]
        KEFAR_MASARYK,
        [Display(Name = "כפר מצר")]
        KAFAR_MISR,
        [Display(Name = "כפר מרדכי")]
        KEFAR_MORDEKHAY,
        [Display(Name = "כפר נטר")]
        KEFAR_NETTER,
        [Display(Name = "כפר סאלד")]
        KEFAR_SZOLD,
        [Display(Name = "כפר סבא")]
        KEFAR_SAVA,
        [Display(Name = "כפר סילבר")]
        KEFAR_SILVER,
        [Display(Name = "כפר סירקין")]
        KEFAR_SIRKIN,
        [Display(Name = "כפר עבודה")]
        KEFAR_AVODA,
        [Display(Name = "כפר עזה")]
        KEFAR_AZZA,
        [Display(Name = "כפר עציון")]
        KEFAR_EZYON,
        [Display(Name = "כפר פינס")]
        KEFAR_PINES,
        [Display(Name = "כפר קאסם")]
        KAFAR_QASEM,
        [Display(Name = "כפר קיש")]
        KEFAR_KISH,
        [Display(Name = "כפר קרע")]
        KAFAR_QARA,
        [Display(Name = "כפר ראש הנקרה")]
        KEFAR_ROSH_HANIQRA,
        [Display(Name = "כפר רוזנואלד )זרעית(")]
        KEFAR_ROZENWALD,
        [Display(Name = "כפר רופין")]
        KEFAR_RUPPIN,
        [Display(Name = "כפר רות")]
        KEFAR_RUT,
        [Display(Name = "כפר שמאי")]
        KEFAR_SHAMMAY,
        [Display(Name = "כפר שמואל")]
        KEFAR_SHEMUEL,
        [Display(Name = "כפר שמריהו")]
        KEFAR_SHEMARYAHU,
        [Display(Name = "כפר תבור")]
        KEFAR_TAVOR,
        [Display(Name = "כפר תפוח")]
        KEFAR_TAPPUAH,
        [Display(Name = "כרי דשא")]
        KARE_DESHE,
        [Display(Name = "כרכום")]
        KARKOM,
        [Display(Name = "כרם בן זמרה")]
        KEREM_BEN_ZIMRA,
        [Display(Name = "כרם בן שמן")]
        KEREM_BEN_SHEMEN,
        [Display(Name = "כרם יבנה")]
        KEREM_YAVNE,
        [Display(Name = "כרם מהר\"ל")]
        KEREM_MAHARAL,
        [Display(Name = "כרם שלום")]
        KEREM_SHALOM,
        [Display(Name = "כרמי יוסף")]
        KARME_YOSEF,
        [Display(Name = "כרמי צור")]
        KARME_ZUR,
        [Display(Name = "כרמי קטיף")]
        KARME_QATIF,
        [Display(Name = "כרמיאל")]
        KARMIEL,
        [Display(Name = "כרמיה")]
        KARMIYYA,
        [Display(Name = "כרמים")]
        KERAMIM,
        [Display(Name = "כרמל")]
        KARMEL,
        [Display(Name = "לבון")]
        LAVON,
        [Display(Name = "לביא")]
        LAVI,
        [Display(Name = "לבנים")]
        LIVNIM,
        [Display(Name = "להב")]
        LAHAV,
        [Display(Name = "להבות הבשן")]
        LAHAVOT_HABASHAN,
        [Display(Name = "להבות חביבה")]
        LAHAVOT_HAVIVA,
        [Display(Name = "להבים")]
        LEHAVIM,
        [Display(Name = "לוד")]
        LOD,
        [Display(Name = "לוזית")]
        LUZIT,
        [Display(Name = "לוחמי הגיטאות")]
        LOHAME_HAGETAOT,
        [Display(Name = "לוטם")]
        LOTEM,
        [Display(Name = "לוטן")]
        LOTAN,
        [Display(Name = "לימן")]
        LIMAN,
        [Display(Name = "לכיש")]
        LAKHISH,
        [Display(Name = "לפיד")]
        LAPPID,
        [Display(Name = "לפידות")]
        LAPPIDOT,
        [Display(Name = "לקיה")]
        LAQYE,
        [Display(Name = "מאור")]
        MAOR,
        [Display(Name = "מאיר שפיה")]
        MEIR_SHEFEYA,
        [Display(Name = "מבוא ביתר")]
        MEVO_BETAR,
        [Display(Name = "מבוא דותן")]
        MEVO_DOTAN,
        [Display(Name = "מבוא חורון")]
        MEVO_HORON,
        [Display(Name = "מבוא חמה")]
        MEVO_HAMMA,
        [Display(Name = "מבוא מודיעים")]
        MEVO_MODIIM,
        [Display(Name = "מבואות ים")]
        MEVOOT_YAM,
        [Display(Name = "מבועים")]
        MABBUIM,
        [Display(Name = "מבטחים")]
        MIVTAHIM,
        [Display(Name = "מבקיעים")]
        MAVQIIM,
        [Display(Name = "מבשרת ציון")]
        MEVASSERET_ZIYYON,
        [Display(Name = "מג'ד אל-כרום")]
        MAJD_AL_KURUM,
        [Display(Name = "מג'דל שמס")]
        MAJDAL_SHAMS,
        [Display(Name = "מגאר")]
        MUGHAR,
        [Display(Name = "מגדים")]
        MEGADIM,
        [Display(Name = "מגדל")]
        MIGDAL,
        [Display(Name = "מגדל העמק")]
        MIGDAL_HAEMEQ,
        [Display(Name = "מגדל עוז")]
        MIGDAL_OZ,
        [Display(Name = "מגדלים")]
        MIGDALIM,
        [Display(Name = "מגידו")]
        MEGIDDO,
        [Display(Name = "מגל")]
        MAGGAL,
        [Display(Name = "מגן")]
        MAGEN,
        [Display(Name = "מגן שאול")]
        MAGEN_SHAUL,
        [Display(Name = "מגשימים")]
        MAGSHIMIM,
        [Display(Name = "מדרך עוז")]
        MIDRAKH_OZ,
        [Display(Name = "מדרשת בן גוריון")]
        MIDRESHET_BEN_GURION,
        [Display(Name = "מדרשת רופין")]
        MIDRESHET_RUPPIN,
        [Display(Name = "מודיעין עילית")]
        MODIIN_ILLIT,
        [Display(Name = "מודיעין-מכבים-רעות")]
        MODIIN_MAKKABBIM_RE,
        [Display(Name = "מולדת")]
        MOLEDET,
        [Display(Name = "מוצא עילית")]
        MOZA_ILLIT,
        [Display(Name = "מוקייבלה")]
        MUQEIBLE,
        [Display(Name = "מורן")]
        MORAN,
        [Display(Name = "מורשת")]
        MORESHET,
        [Display(Name = "מזור")]
        MAZOR,
        [Display(Name = "מזכרת בתיה")]
        MAZKERET_BATYA,
        [Display(Name = "מזרע")]
        MIZRA,
        [Display(Name = "מזרעה")]
        MAZRAA,
        [Display(Name = "מחולה")]
        MEHOLA,
        [Display(Name = "מחנה הילה")]
        MAHANE_HILLA,
        [Display(Name = "מחנה טלי")]
        MAHANE_TALI,
        [Display(Name = "מחנה יהודית")]
        MAHANE_YEHUDIT,
        [Display(Name = "מחנה יוכבד")]
        MAHANE_YOKHVED,
        [Display(Name = "מחנה יפה")]
        MAHANE_YAFA,
        [Display(Name = "מחנה יתיר")]
        MAHANE_YATTIR,
        [Display(Name = "מחנה מרים")]
        MAHANE_MIRYAM,
        [Display(Name = "מחנה תל נוף")]
        MAHANE_TEL_NOF,
        [Display(Name = "מחניים")]
        MAHANAYIM,
        [Display(Name = "מחסיה")]
        MAHSEYA,
        [Display(Name = "מטולה")]
        METULA,
        [Display(Name = "מטע")]
        MATTA,
        [Display(Name = "מי עמי")]
        ME_AMMI,
        [Display(Name = "מיטב")]
        METAV,
        [Display(Name = "מייסר")]
        MEISER,
        [Display(Name = "מיצר")]
        MEZAR,
        [Display(Name = "מירב")]
        MERAV,
        [Display(Name = "מירון")]
        MERON,
        [Display(Name = "מישר")]
        MESHAR,
        [Display(Name = "מיתר")]
        METAR,
        [Display(Name = "מכורה")]
        MEKHORA,
        [Display(Name = "מכחול")]
        MAKCHUL,
        [Display(Name = "מכמורת")]
        MIKHMORET,
        [Display(Name = "מכמנים")]
        MIKHMANNIM,
        [Display(Name = "מלאה")]
        MELEA,
        [Display(Name = "מלילות")]
        MELILOT,
        [Display(Name = "מלכיה")]
        MALKIYYA,
        [Display(Name = "מלכישוע")]
        MALKISHUA,
        [Display(Name = "מנוחה")]
        MENUHA,
        [Display(Name = "מנוף")]
        MANOF,
        [Display(Name = "מנות")]
        MANOT,
        [Display(Name = "מנחמיה")]
        MENAHEMYA,
        [Display(Name = "מנרה")]
        MENNARA,
        [Display(Name = "מנשית זבדה")]
        MANSHIYYET_ZABDA,
        [Display(Name = "מסד")]
        MASSAD,
        [Display(Name = "מסדה")]
        MASSADA,
        [Display(Name = "מסילות")]
        MESILLOT,
        [Display(Name = "מסילת ציון")]
        MESILLAT_ZIYYON,
        [Display(Name = "מסלול")]
        MASLUL,
        [Display(Name = "מסעדה")]
        MASADE,
        [Display(Name = "מסעודין אל-עזאזמה")]
        MASUDIN_AL_AZAZME,
        [Display(Name = "מעברות")]
        MABAROT,
        [Display(Name = "מעגלים")]
        MAGALIM,
        [Display(Name = "מעגן")]
        MAAGAN,
        [Display(Name = "מעגן מיכאל")]
        MAAGAN_MIKHAEL,
        [Display(Name = "מעוז חיים")]
        MAOZ_HAYYIM,
        [Display(Name = "מעון")]
        MAON,
        [Display(Name = "מעונה")]
        MEONA,
        [Display(Name = "מעיליא")]
        MIELYA,
        [Display(Name = "מעין ברוך")]
        MAYAN_BARUKH,
        [Display(Name = "מעין צבי")]
        MAYAN_ZEVI,
        [Display(Name = "מעלה אדומים")]
        MAALE_ADUMMIM,
        [Display(Name = "מעלה אפרים")]
        MAALE_EFRAYIM,
        [Display(Name = "מעלה גלבוע")]
        MAALE_GILBOA,
        [Display(Name = "מעלה גמלא")]
        MAALE_GAMLA,
        [Display(Name = "מעלה החמישה")]
        MAALE_HAHAMISHA,
        [Display(Name = "מעלה לבונה")]
        MAALE_LEVONA,
        [Display(Name = "מעלה מכמש")]
        MAALE_MIKHMAS,
        [Display(Name = "מעלה עירון")]
        MAALE_IRON,
        [Display(Name = "מעלה עמוס")]
        MAALE_AMOS,
        [Display(Name = "מעלה שומרון")]
        MAALE_SHOMERON,
        [Display(Name = "מעלות-תרשיחא")]
        MAALOT_TARSHIHA,
        [Display(Name = "מענית")]
        MAANIT,
        [Display(Name = "מעש")]
        MAAS,
        [Display(Name = "מפלסים")]
        MEFALLESIM,
        [Display(Name = "מצדות יהודה")]
        MEZADOT_YEHUDA,
        [Display(Name = "מצובה")]
        MAZZUVA,
        [Display(Name = "מצליח")]
        MAZLIAH,
        [Display(Name = "מצפה")]
        MIZPA,
        [Display(Name = "מצפה אבי\"ב")]
        MIZPE_AVIV,
        [Display(Name = "מצפה אילן")]
        MITSPE_ILAN,
        [Display(Name = "מצפה יריחו")]
        MIZPE_YERIHO,
        [Display(Name = "מצפה נטופה")]
        MIZPE_NETOFA,
        [Display(Name = "מצפה רמון")]
        MIZPE_RAMON,
        [Display(Name = "מצפה שלם")]
        MIZPE_SHALEM,
        [Display(Name = "מצר")]
        MEZER,
        [Display(Name = "מקווה ישראל")]
        MIQWE_YISRAEL,
        [Display(Name = "מרגליות")]
        MARGALIYYOT,
        [Display(Name = "מרום גולן")]
        MEROM_GOLAN,
        [Display(Name = "מרחב עם")]
        MERHAV_AM,
        [Display(Name = "מרחביה")]
        MERHAVYA,
        [Display(Name = "מרכז שפירא")]
        MERKAZ_SHAPPIRA,
        [Display(Name = "משאבי שדה")]
        MASHABBE_SADE,
        [Display(Name = "משגב דב")]
        MISGAV_DOV,
        [Display(Name = "משגב עם")]
        MISGAV_AM,
        [Display(Name = "משהד")]
        MESHHED,
        [Display(Name = "משואה")]
        MASSUA,
        [Display(Name = "משואות יצחק")]
        MASSUOT_YIZHAQ,
        [Display(Name = "משכיות")]
        MASKIYYOT,
        [Display(Name = "משמר איילון")]
        MISHMAR_AYYALON,
        [Display(Name = "משמר דוד")]
        MISHMAR_DAWID,
        [Display(Name = "משמר הירדן")]
        MISHMAR_HAYARDEN,
        [Display(Name = "משמר הנגב")]
        MISHMAR_HANEGEV,
        [Display(Name = "משמר העמק")]
        MISHMAR_HAEMEQ,
        [Display(Name = "משמר השבעה")]
        MISHMAR_HASHIVA,
        [Display(Name = "משמר השרון")]
        MISHMAR_HASHARON,
        [Display(Name = "משמרות")]
        MISHMAROT,
        [Display(Name = "משמרת")]
        MISHMERET,
        [Display(Name = "משען")]
        MASHEN,
        [Display(Name = "מתן")]
        MATTAN,
        [Display(Name = "מתת")]
        MATTAT,
        [Display(Name = "מתתיהו")]
        MATTITYAHU,
        [Display(Name = "נאות גולן")]
        NEOT_GOLAN,
        [Display(Name = "נאות הכיכר")]
        NEOT_HAKIKKAR,
        [Display(Name = "נאות מרדכי")]
        NEOT_MORDEKHAY,
        [Display(Name = "נאות סמדר")]
        SHIZZAFON,
        [Display(Name = "נאעורה")]
        NAURA,
        [Display(Name = "נבטים")]
        NEVATIM,
        [Display(Name = "נגבה")]
        NEGBA,
        [Display(Name = "נגוהות")]
        NEGOHOT,
        [Display(Name = "נהורה")]
        NEHORA,
        [Display(Name = "נהלל")]
        NAHALAL,
        [Display(Name = "נהריה")]
        NAHARIYYA,
        [Display(Name = "נוב")]
        NOV,
        [Display(Name = "נוגה")]
        NOGAH,
        [Display(Name = "נווה")]
        
    
    
    
    
    E,
        [Display(Name = "נווה אבות")]
        NEWE_AVOT,
        [Display(Name = "נווה אור")]
        NEWE_UR,
        [Display(Name = "נווה אטי\"ב")]
        NEWE_ATIV,
        [Display(Name = "נווה אילן")]
        NEWE_ILAN,
        [Display(Name = "נווה איתן")]
        NEWE_ETAN,
        [Display(Name = "נווה דניאל")]
        NEWE_DANIYYEL,
        [Display(Name = "נווה זוהר")]
        NEWE_ZOHAR,
        [Display(Name = "נווה זיו")]
        NEWE_ZIV,
        [Display(Name = "נווה חריף")]
        NEWE_HARIF,
        [Display(Name = "נווה ים")]
        NEWE_YAM,
        [Display(Name = "נווה ימין")]
        NEWE_YAMIN,
        [Display(Name = "נווה ירק")]
        NEWE_YARAQ,
        [Display(Name = "נווה מבטח")]
        NEWE_MIVTAH,
        [Display(Name = "נווה מיכאל")]
        NEWE_MIKHAEL,
        [Display(Name = "נווה שלום")]
        NEWE_SHALOM,
        [Display(Name = "נועם")]
        NOAM,
        [Display(Name = "נוף איילון")]
        NOF_AYYALON,
        [Display(Name = "נופים")]
        NOFIM,
        [Display(Name = "נופית")]
        NOFIT,
        [Display(Name = "נופך")]
        NOFEKH,
        [Display(Name = "נוקדים")]
        NOQEDIM,
        [Display(Name = "נורדיה")]
        NORDIYYA,
        [Display(Name = "נורית")]
        NURIT,
        [Display(Name = "נחושה")]
        NEHUSHA,
        [Display(Name = "נחל עוז")]
        NAHAL_OZ,
        [Display(Name = "נחלה")]
        NAHALA,
        [Display(Name = "נחליאל")]
        NAHALIEL,
        [Display(Name = "נחלים")]
        NEHALIM,
        [Display(Name = "נחם")]
        NAHAM,
        [Display(Name = "נחף")]
        NAHEF,
        [Display(Name = "נחשולים")]
        NAHSHOLIM,
        [Display(Name = "נחשון")]
        NAHSHON,
        [Display(Name = "נחשונים")]
        NAHSHONIM,
        [Display(Name = "נטועה")]
        NETUA,
        [Display(Name = "נטור")]
        NATUR,
        [Display(Name = "נטע")]
        NETA,
        [Display(Name = "נטעים")]
        NETAIM,
        [Display(Name = "נטף")]
        NATAF,
        [Display(Name = "ניין")]
        NEIN,
        [Display(Name = "ניל\"י")]
        NILI,
        [Display(Name = "ניצן")]
        NIZZAN,
        [Display(Name = "ניצן ב'")]
        NIZZAN_B,
        [Display(Name = "ניצני סיני")]
        NIZZANE_SINAY,
        [Display(Name = "ניצני עוז")]
        NIZZANE_OZ,
        [Display(Name = "ניצנים")]
        NIZZANIM,
        [Display(Name = "ניר אליהו")]
        NIR_ELIYYAHU,
        [Display(Name = "ניר בנים")]
        NIR_BANIM,
        [Display(Name = "ניר גלים")]
        NIR_GALLIM,
        [Display(Name = "ניר דוד )תל עמל(")]
        NIR_DAWID,
        [Display(Name = "ניר ח\"ן")]
        NIR_HEN,
        [Display(Name = "ניר יפה")]
        NIR_YAFE,
        [Display(Name = "ניר יצחק")]
        NIR_YIZHAQ,
        [Display(Name = "ניר ישראל")]
        NIR_YISRAEL,
        [Display(Name = "ניר משה")]
        NIR_MOSHE,
        [Display(Name = "ניר עוז")]
        NIR_OZ,
        [Display(Name = "ניר עם")]
        NIR_AM,
        [Display(Name = "ניר עציון")]
        NIR_EZYON,
        [Display(Name = "ניר עקיבא")]
        NIR_AQIVA,
        [Display(Name = "ניר צבי")]
        NIR_ZEVI,
        [Display(Name = "נירים")]
        NIRIM,
        [Display(Name = "נירית")]
        NIRIT,
        [Display(Name = "נירן")]
        NIRAN,
        [Display(Name = "נמרוד")]
        NIMROD,
        [Display(Name = "נס הרים")]
        NES_HARIM,
        [Display(Name = "נס עמים")]
        NES_AMMIM,
        [Display(Name = "נס ציונה")]
        NES_ZIYYONA,
        [Display(Name = "נעורים")]
        NEURIM,
        [Display(Name = "נעלה")]
        NAALE,
        [Display(Name = "נעמ\"ה")]
        NAAMA,
        [Display(Name = "נען")]
        NAAN,
        [Display(Name = "נצאצרה")]
        NASASRA,
        [Display(Name = "נצר חזני")]
        NEZER_HAZZANI,
        [Display(Name = "נצר סרני")]
        NEZER_SERENI,
        [Display(Name = "נצרת")]
        NAZARETH,
        [Display(Name = "נצרת עילית")]
        NAZERAT_ILLIT,
        [Display(Name = "נשר")]
        NESHER,
        [Display(Name = "נתיב הגדוד")]
        NETIV_HAGEDUD,
        [Display(Name = "נתיב הל\"ה")]
        NETIV_HALAMED_HE,
        [Display(Name = "נתיב העשרה")]
        NETIV_HAASARA,
        [Display(Name = "נתיב השיירה")]
        NETIV_HASHAYYARA,
        [Display(Name = "נתיבות")]
        NETIVOT,
        [Display(Name = "נתניה")]
        NETANYA,
        [Display(Name = "סאג'ור")]
        SAJUR,
        [Display(Name = "סאסא")]
        SASA,
        [Display(Name = "סביון")]
        SAVYON,
        [Display(Name = "סגולה")]
        SEGULA,
        [Display(Name = "סואעד")]
        SAWAID,
        [Display(Name = "סולם")]
        SULAM,
        [Display(Name = "סוסיה")]
        SUSEYA,
        [Display(Name = "סופה")]
        SUFA,
        [Display(Name = "סח'נין")]
        SAKHNIN,
        [Display(Name = "סייד")]
        SAYYID,
        [Display(Name = "סלמה")]
        SALLAMA,
        [Display(Name = "סלעית")]
        SALIT,
        [Display(Name = "סמר")]
        SAMAR,
        [Display(Name = "סנסנה")]
        SANSANA,
        [Display(Name = "סעד")]
        SAAD,
        [Display(Name = "סעוה")]
        SAWA,
        [Display(Name = "סער")]
        SAAR,
        [Display(Name = "ספיר")]
        SAPPIR,
        [Display(Name = "סתריה")]
        SITRIYYA,
        [Display(Name = "ע'ג'ר")]
        GHAJAR,
        [Display(Name = "עבדון")]
        AVDON,
        [Display(Name = "עברון")]
        EVRON,
        [Display(Name = "עגור")]
        AGUR,
        [Display(Name = "עדי")]
        ADI,
        [Display(Name = "עדנים")]
        ADANIM,
        [Display(Name = "עוזה")]
        UZA,
        [Display(Name = "עוזייר")]
        UZEIR,
        [Display(Name = "עולש")]
        OLESH,
        [Display(Name = "עומר")]
        OMER,
        [Display(Name = "עופר")]
        OFER,
        [Display(Name = "עופרה")]
        OFRA,
        [Display(Name = "עוצם")]
        OZEM,
        [Display(Name = "עוקבי )בנו עוקבה(")]
        UQBI,
        [Display(Name = "עזוז")]
        EZUZ,
        [Display(Name = "עזר")]
        EZER,
        [Display(Name = "עזריאל")]
        AZRIEL,
        [Display(Name = "עזריה")]
        AZARYA,
        [Display(Name = "עזריקם")]
        AZRIQAM,
        [Display(Name = "עטאוונה")]
        ATAWNE,
        [Display(Name = "עטרת")]
        ATERET,
        [Display(Name = "עידן")]
        IDDAN,
        [Display(Name = "עיילבון")]
        EILABUN,
        [Display(Name = "עיינות")]
        AYANOT,
        [Display(Name = "עילוט")]
        ILUT,
        [Display(Name = "עין איילה")]
        EN_AYYALA,
        [Display(Name = "עין אל-אסד")]
        EIN_AL_ASAD,
        [Display(Name = "עין גב")]
        EN_GEV,
        [Display(Name = "עין גדי")]
        EN_GEDI,
        [Display(Name = "עין דור")]
        EN_DOR,
        [Display(Name = "עין הבשור")]
        EN_HABESOR,
        [Display(Name = "עין הוד")]
        EN_HOD,
        [Display(Name = "עין החורש")]
        EN_HAHORESH,
        [Display(Name = "עין המפרץ")]
        EN_HAMIFRAZ,
        [Display(Name = "עין הנצי\"ב")]
        EN_HANAZIV,
        [Display(Name = "עין העמק")]
        EN_HAEMEQ,
        [Display(Name = "עין השופט")]
        EN_HASHOFET,
        [Display(Name = "עין השלושה")]
        EN_HASHELOSHA,
        [Display(Name = "עין ורד")]
        EN_WERED,
        [Display(Name = "עין זיוון")]
        EN_ZIWAN,
        [Display(Name = "עין חוד")]
        EIN_HOD,
        [Display(Name = "עין חצבה")]
        EN_HAZEVA,
        [Display(Name = "עין חרוד")]
        EN_HAROD,
        [Display(Name = "עין יהב")]
        EN_YAHAV,
        [Display(Name = "עין יעקב")]
        EN_YAAQOV,
        [Display(Name = "עין כרם-בי\"ס חקלאי")]
        EN_KAREM_BS_HAQLAI,
        [Display(Name = "עין כרמל")]
        EN_KARMEL,
        [Display(Name = "עין מאהל")]
        EIN_MAHEL,
        [Display(Name = "עין נקובא")]
        EIN_NAQQUBA,
        [Display(Name = "עין עירון")]
        EN_IRON,
        [Display(Name = "עין צורים")]
        EN_ZURIM,
        [Display(Name = "עין קנייא")]
        EIN_QINIYYE,
        [Display(Name = "עין ראפה")]
        EIN_RAFA,
        [Display(Name = "עין שמר")]
        EN_SHEMER,
        [Display(Name = "עין שריד")]
        EN_SARID,
        [Display(Name = "עין תמר")]
        EN_TAMAR,
        [Display(Name = "עינת")]
        ENAT,
        [Display(Name = "עיר אובות")]
        IR_OVOT,
        [Display(Name = "עכו")]
        AKKO,
        [Display(Name = "עלומים")]
        ALUMIM,
        [Display(Name = "עלי")]
        ELI,
        [Display(Name = "עלי זהב")]
        ALE_ZAHAV,
        [Display(Name = "עלמה")]
        ALMA,
        [Display(Name = "עלמון")]
        ALMON,
        [Display(Name = "עמוקה")]
        AMUQQA,
        [Display(Name = "עמיחי")]
        AMMIHAY,
        [Display(Name = "עמינדב")]
        AMMINADAV,
        [Display(Name = "עמיעד")]
        AMMIAD,
        [Display(Name = "עמיעוז")]
        AMMIOZ,
        [Display(Name = "עמיקם")]
        AMMIQAM,
        [Display(Name = "עמיר")]
        AMIR,
        [Display(Name = "עמנואל")]
        IMMANUEL,
        [Display(Name = "עמקה")]
        AMQA,
        [Display(Name = "ענב")]
        ENAV,
        [Display(Name = "עספיא")]
        ISIFYA,
        [Display(Name = "עפולה")]
        AFULA,
        [Display(Name = "עץ אפרים")]
        EZ_EFRAYIM,
        [Display(Name = "עצמון שגב")]
        ATSMON_SEGEV,
        [Display(Name = "עראבה")]
        ARRABE,
        [Display(Name = "עראמשה")]
        ARAMSHA,
        [Display(Name = "ערב אל נעים")]
        ARRAB_AL_NAIM,
        [Display(Name = "ערד")]
        ARAD,
        [Display(Name = "ערוגות")]
        ARUGOT,
        [Display(Name = "ערערה")]
        ARARA,
        [Display(Name = "ערערה-בנגב")]
        ARARA_BANEGEV,
        [Display(Name = "עשרת")]
        ASERET,
        [Display(Name = "עתלית")]
        ATLIT,
        [Display(Name = "עתניאל")]
        OTNIEL,
        [Display(Name = "פארן")]
        PARAN,
        [Display(Name = "פדואל")]
        PEDUEL,
        [Display(Name = "פדויים")]
        PEDUYIM,
        [Display(Name = "פדיה")]
        PEDAYA,
        [Display(Name = "פוריה - כפר עבודה")]
        PORIYYA_KEFAR_AVODA,
        [Display(Name = "פוריה - נווה עובד")]
        PORIYYA_NEWE_OVED,
        [Display(Name = "פוריה עילית")]
        PORIYYA_ILLIT,
        [Display(Name = "פוריידיס")]
        FUREIDIS,
        [Display(Name = "פורת")]
        PORAT,
        [Display(Name = "פטיש")]
        PATTISH,
        [Display(Name = "פלך")]
        PELEKH,
        [Display(Name = "פלמחים")]
        PALMAHIM,
        [Display(Name = "פני חבר")]
        PENE_HEVER,
        [Display(Name = "פסגות")]
        PESAGOT,
        [Display(Name = "פסוטה")]
        FASSUTA,
        [Display(Name = "פעמי תש\"ז")]
        PAAME_TASHAZ,
        [Display(Name = "פצאל")]
        PEZAEL,
        [Display(Name = "פקיעין )בוקייעה(")]
        PEQIIN,
        [Display(Name = "פקיעין חדשה")]
        PEQIIN_HADASHA,
        [Display(Name = "פרדס חנה-כרכור")]
        PARDES_HANNA_KARKUR,
        [Display(Name = "פרדסיה")]
        PARDESIYYA,
        [Display(Name = "פרוד")]
        PAROD,
        [Display(Name = "פרזון")]
        PERAZON,
        [Display(Name = "פרי גן")]
        PERI_GAN,
        [Display(Name = "פתח תקווה")]
        PETAH_TIQWA,
        [Display(Name = "פתחיה")]
        PETAHYA,
        [Display(Name = "צאלים")]
        ZEELIM,
        [Display(Name = "צביה")]
        ZVIYYA,
        [Display(Name = "צבעון")]
        ZIVON,
        [Display(Name = "צובה")]
        ZOVA,
        [Display(Name = "צוחר")]
        TZOHAR,
        [Display(Name = "צופיה")]
        ZOFIYYA,
        [Display(Name = "צופים")]
        ZUFIN,
        [Display(Name = "צופית")]
        ZOFIT,
        [Display(Name = "צופר")]
        ZOFAR,
        [Display(Name = "צוקי ים")]
        SHOSHANNAT_YAM,
        [Display(Name = "צוקים")]
        MAHANE_BILDAD,
        [Display(Name = "צור הדסה")]
        ZUR_HADASSA,
        [Display(Name = "צור יצחק")]
        ZUR_YIZHAQ,
        [Display(Name = "צור משה")]
        ZUR_MOSHE,
        [Display(Name = "צור נתן")]
        ZUR_NATAN,
        [Display(Name = "צוריאל")]
        ZURIEL,
        [Display(Name = "צורית")]
        ZURIT,
        [Display(Name = "ציפורי")]
        ZIPPORI,
        [Display(Name = "צלפון")]
        ZELAFON,
        [Display(Name = "צנדלה")]
        SANDALA,
        [Display(Name = "צפריה")]
        ZAFRIYYA,
        [Display(Name = "צפרירים")]
        ZAFRIRIM,
        [Display(Name = "צפת")]
        ZEFAT,
        [Display(Name = "צרופה")]
        ZERUFA,
        [Display(Name = "צרעה")]
        ZORA,
        [Display(Name = "קבועה")]
        QABBOA,
        [Display(Name = "קבוצת יבנה")]
        QEVUZAT_YAVNE,
        [Display(Name = "קדומים")]
        QEDUMIM,
        [Display(Name = "קדימה-צורן")]
        QADIMA_ZORAN,
        [Display(Name = "קדמה")]
        QEDMA,
        [Display(Name = "קדמת צבי")]
        QIDMAT_ZEVI,
        [Display(Name = "קדר")]
        QEDAR,
        [Display(Name = "קדרון")]
        QIDRON,
        [Display(Name = "קדרים")]
        QADDARIM,
        [Display(Name = "קודייראת א-צאנע")]
        QUDEIRAT_AS_SANI,
        [Display(Name = "קוואעין")]
        QAWAIN,
        [Display(Name = "קוממיות")]
        QOMEMIYYUT,
        [Display(Name = "קורנית")]
        QORANIT,
        [Display(Name = "קטורה")]
        QETURA,
        [Display(Name = "קיסריה")]
        QESARIYYA,
        [Display(Name = "קלחים")]
        QELAHIM,
        [Display(Name = "קליה")]
        QALYA,
        [Display(Name = "קלנסווה")]
        QALANSAWE,
        [Display(Name = "קלע")]
        QELA,
        [Display(Name = "קציר")]
        QAZIR,
        [Display(Name = "קצר א-סר")]
        QASR_AL_SIR,
        [Display(Name = "קצרין")]
        QAZRIN,
        [Display(Name = "קרית אונו")]
        QIRYAT_ONO,
        [Display(Name = "קרית ארבע")]
        QIRYAT_ARBA,
        [Display(Name = "קרית אתא")]
        QIRYAT_ATTA,
        [Display(Name = "קרית ביאליק")]
        QIRYAT_BIALIK,
        [Display(Name = "קרית גת")]
        QIRYAT_GAT,
        [Display(Name = "קרית טבעון")]
        QIRYAT_TIVON,
        [Display(Name = "קרית ים")]
        QIRYAT_YAM,
        [Display(Name = "קרית יערים")]
        QIRYAT_YEARIM,
        [Display(Name = "קרית מוצקין")]
        QIRYAT_MOTZKIN,
        [Display(Name = "קרית מלאכי")]
        QIRYAT_MALAKHI,
        [Display(Name = "קרית נטפים")]
        QIRYAT_NETAFIM,
        [Display(Name = "קרית ענבים")]
        QIRYAT_ANAVIM,
        [Display(Name = "קרית עקרון")]
        QIRYAT_EQRON,
        [Display(Name = "קרית שלמה")]
        QIRYAT_SHELOMO,
        [Display(Name = "קרית שמונה")]
        QIRYAT_SHEMONA,
        [Display(Name = "קרני שומרון")]
        QARNE_SHOMERON,
        [Display(Name = "קשת")]
        QESHET,
        [Display(Name = "ראמה")]
        RAME,
        [Display(Name = "ראס אל-עין")]
        RAS_AL_EIN,
        [Display(Name = "ראס עלי")]
        RAS_ALI,
        [Display(Name = "ראש העין")]
        ROSH_HAAYIN,
        [Display(Name = "ראש פינה")]
        ROSH_PINNA,
        [Display(Name = "ראש צורים")]
        ROSH_ZURIM,
        [Display(Name = "ראשון לציון")]
        RISHON_LEZIYYON,
        [Display(Name = "רבבה")]
        REVAVA,
        [Display(Name = "רבדים")]
        REVADIM,
        [Display(Name = "רביבים")]
        REVIVIM,
        [Display(Name = "רביד")]
        RAVID,
        [Display(Name = "רגבה")]
        REGBA,
        [Display(Name = "רגבים")]
        REGAVIM,
        [Display(Name = "רהט")]
        RAHAT,
        [Display(Name = "רווחה")]
        REWAHA,
        [Display(Name = "רוויה")]
        REWAYA,
        [Display(Name = "רוח מדבר")]
        RUAH_MIDBAR,
        [Display(Name = "רוחמה")]
        RUHAMA,
        [Display(Name = "רומאנה")]
        RUMMANE,
        [Display(Name = "רומת הייב")]
        RUMAT_HEIB,
        [Display(Name = "רועי")]
        ROI,
        [Display(Name = "רותם")]
        ROTEM,
        [Display(Name = "רחוב")]
        REHOV,
        [Display(Name = "רחובות")]
        REHOVOT,
        [Display(Name = "רחלים")]
        REHELIM,
        [Display(Name = "ריחאניה")]
        REIHANIYYE,
        [Display(Name = "ריחן")]
        REHAN,
        [Display(Name = "ריינה")]
        REINE,
        [Display(Name = "רימונים")]
        RIMMONIM,
        [Display(Name = "רינתיה")]
        RINNATYA,
        [Display(Name = "רכסים")]
        REKHASIM,
        [Display(Name = "רם-און")]
        RAM_ON,
        [Display(Name = "רמות")]
        RAMOT,
        [Display(Name = "רמות השבים")]
        RAMOT_HASHAVIM,
        [Display(Name = "רמות מאיר")]
        RAMOT_MEIR,
        [Display(Name = "רמות מנשה")]
        RAMOT_MENASHE,
        [Display(Name = "רמות נפתלי")]
        RAMOT_NAFTALI,
        [Display(Name = "רמלה")]
        RAMLA,
        [Display(Name = "רמת גן")]
        RAMAT_GAN,
        [Display(Name = "רמת דוד")]
        RAMAT_DAWID,
        [Display(Name = "רמת הכובש")]
        RAMAT_HAKOVESH,
        [Display(Name = "רמת השופט")]
        RAMAT_HASHOFET,
        [Display(Name = "רמת השרון")]
        RAMAT_HASHARON,
        [Display(Name = "רמת יוחנן")]
        RAMAT_YOHANAN,
        [Display(Name = "רמת ישי")]
        RAMAT_YISHAY,
        [Display(Name = "רמת מגשימים")]
        RAMAT_MAGSHIMIM,
        [Display(Name = "רמת צבי")]
        RAMAT_ZEVI,
        [Display(Name = "רמת רזיאל")]
        RAMAT_RAZIEL,
        [Display(Name = "רמת רחל")]
        RAMAT_RAHEL,
        [Display(Name = "רנן")]
        RANNEN,
        [Display(Name = "רעים")]
        REIM,
        [Display(Name = "רעננה")]
        RAANANA,
        [Display(Name = "רקפת")]
        RAQEFET,
        [Display(Name = "רשפון")]
        RISHPON,
        [Display(Name = "רשפים")]
        RESHAFIM,
        [Display(Name = "רתמים")]
        RETAMIM,
        [Display(Name = "שאר ישוב")]
        SHEAR_YASHUV,
        [Display(Name = "שבי דרום")]
        SHAVE_DAROM,
        [Display(Name = "שבי ציון")]
        SHAVE_ZIYYON,
        [Display(Name = "שבי שומרון")]
        SHAVE_SHOMERON,
        [Display(Name = "שבלי - אום אל-גנם")]
        SHIBLI,
        [Display(Name = "שגב-שלום")]
        SEGEV_SHALOM,
        [Display(Name = "שדה אילן")]
        SEDE_ILAN,
        [Display(Name = "שדה אליהו")]
        SEDE_ELIYYAHU,
        [Display(Name = "שדה אליעזר")]
        SEDE_ELIEZER,
        [Display(Name = "שדה בוקר")]
        SEDE_BOQER,
        [Display(Name = "שדה דוד")]
        SEDE_DAWID,
        [Display(Name = "שדה ורבורג")]
        SEDE_WARBURG,
        [Display(Name = "שדה יואב")]
        SEDE_YOAV,
        [Display(Name = "שדה יעקב")]
        SEDE_YAAQOV,
        [Display(Name = "שדה יצחק")]
        SEDE_YIZHAQ,
        [Display(Name = "שדה משה")]
        SEDE_MOSHE,
        [Display(Name = "שדה נחום")]
        SEDE_NAHUM,
        [Display(Name = "שדה נחמיה")]
        SEDE_NEHEMYA,
        [Display(Name = "שדה ניצן")]
        SEDE_NIZZAN,
        [Display(Name = "שדה עוזיהו")]
        SEDE_UZZIYYAHU,
        [Display(Name = "שדה צבי")]
        SEDE_ZEVI,
        [Display(Name = "שדות ים")]
        SEDOT_YAM,
        [Display(Name = "שדות מיכה")]
        SEDOT_MIKHA,
        [Display(Name = "שדי אברהם")]
        SEDE_AVRAHAM,
        [Display(Name = "שדי חמד")]
        SEDE_HEMED,
        [Display(Name = "שדי תרומות")]
        SEDE_TERUMOT,
        [Display(Name = "שדמה")]
        SHEDEMA,
        [Display(Name = "שדמות דבורה")]
        SHADMOT_DEVORA,
        [Display(Name = "שדמות מחולה")]
        SHADMOT_MEHOLA,
        [Display(Name = "שדרות")]
        SEDEROT,
        [Display(Name = "שואבה")]
        SHOEVA,
        [Display(Name = "שובה")]
        SHUVA,
        [Display(Name = "שובל")]
        SHOVAL,
        [Display(Name = "שוהם")]
        SHOHAM,
        [Display(Name = "שומרה")]
        SHOMERA,
        [Display(Name = "שומריה")]
        SHOMERIYYA,
        [Display(Name = "שוקדה")]
        SHOQEDA,
        [Display(Name = "שורש")]
        SHORESH,
        [Display(Name = "שורשים")]
        SHORASHIM,
        [Display(Name = "שושנת העמקים")]
        SHOSHANNAT_HAAMAQIM,
        [Display(Name = "שזור")]
        SHEZOR,
        [Display(Name = "שחר")]
        SHAHAR,
        [Display(Name = "שחרות")]
        SHAHARUT,
        [Display(Name = "שיבולים")]
        SHIBBOLIM,
        [Display(Name = "שיטים")]
        NAHAL_SHITTIM,
        [Display(Name = "שייח' דנון")]
        SHEIKH_DANNUN,
        [Display(Name = "שילה")]
        SHILO,
        [Display(Name = "שילת")]
        SHILAT,
        [Display(Name = "שכניה")]
        SHEKHANYA,
        [Display(Name = "שלווה")]
        SHALWA,
        [Display(Name = "שלווה במדבר")]
        SHALVA_BAMIDBAR,
        [Display(Name = "שלוחות")]
        SHELUHOT,
        [Display(Name = "שלומי")]
        SHELOMI,
        [Display(Name = "שלומית")]
        SHLOMIT,
        [Display(Name = "שמיר")]
        SHAMIR,
        [Display(Name = "שמעה")]
        SHIMA,
        [Display(Name = "שמרת")]
        SHAMERAT,
        [Display(Name = "שמשית")]
        SHIMSHIT,
        [Display(Name = "שני")]
        SHANI,
        [Display(Name = "שניר")]
        SENIR,
        [Display(Name = "שעב")]
        SHAAB,
        [Display(Name = "שעורים")]
        SEORIM,
        [Display(Name = "שעל")]
        SHAAL,
        [Display(Name = "שעלבים")]
        SHAALVIM,
        [Display(Name = "שער אפרים")]
        SHAAR_EFRAYIM,
        [Display(Name = "שער הגולן")]
        SHAAR_HAGOLAN,
        [Display(Name = "שער העמקים")]
        SHAAR_HAAMAQIM,
        [Display(Name = "שער מנשה")]
        SHAAR_MENASHE,
        [Display(Name = "שערי תקווה")]
        SHAARE_TIQWA,
        [Display(Name = "שפיים")]
        SHEFAYIM,
        [Display(Name = "שפיר")]
        SHAFIR,
        [Display(Name = "שפר")]
        SHEFER,
        [Display(Name = "שפרעם")]
        SHEFARAM,
        [Display(Name = "שקד")]
        SHAQED,
        [Display(Name = "שקף")]
        SHEQEF,
        [Display(Name = "שרונה")]
        SHARONA,
        [Display(Name = "שריגים )לי-און(")]
        LI_ON,
        [Display(Name = "שריד")]
        SARID,
        [Display(Name = "שרשרת")]
        SHARSHERET,
        [Display(Name = "שתולה")]
        SHETULA,
        [Display(Name = "שתולים")]
        SHETULIM,
        [Display(Name = "תאשור")]
        TEASHUR,
        [Display(Name = "תדהר")]
        TIDHAR,
        [Display(Name = "תובל")]
        TUVAL,
        [Display(Name = "תומר")]
        TOMER,
        [Display(Name = "תושיה")]
        TUSHIYYA,
        [Display(Name = "תימורים")]
        TIMMORIM,
        [Display(Name = "תירוש")]
        TIROSH,
        [Display(Name = "תל אביב - יפו")]
        TEL_AVIV_YAFO,
        [Display(Name = "תל יוסף")]
        TEL_YOSEF,
        [Display(Name = "תל יצחק")]
        TEL_YIZHAQ,
        [Display(Name = "תל מונד")]
        TEL_MOND,
        [Display(Name = "תל עדשים")]
        TEL_ADASHIM,
        [Display(Name = "תל קציר")]
        TEL_QAZIR,
        [Display(Name = "תל שבע")]
        TEL_SHEVA,
        [Display(Name = "תל תאומים")]
        TEL_TEOMIM,
        [Display(Name = "תלם")]
        TELEM,
        [Display(Name = "תלמי אליהו")]
        TALME_ELIYYAHU,
        [Display(Name = "תלמי אלעזר")]
        TALME_ELAZAR,
        [Display(Name = "תלמי ביל\"ו")]
        TALME_BILU,
        [Display(Name = "תלמי יוסף")]
        TALME_YOSEF,
        [Display(Name = "תלמי יחיאל")]
        TALME_YEHIEL,
        [Display(Name = "תלמי יפה")]
        TALME_YAFE,
        [Display(Name = "תלמים")]
        TELAMIM,
        [Display(Name = "תמרת")]
        TIMRAT,
        [Display(Name = "תנובות")]
        TENUVOT,
        [Display(Name = "תעוז")]
        TAOZ,
        [Display(Name = "תפרח")]
        TIFRAH,
        [Display(Name = "תקומה")]
        TEQUMA,
        [Display(Name = "תקוע")]
        TEQOA,
        [Display(Name = "תראבין א-צאנע")]
        TARABIN_AS_SANI,
        [Display(Name = "תרום")]
        TARUM,

    }*/
}