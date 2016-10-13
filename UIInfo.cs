using System;

namespace Lab3
{

	public class UIInfo
	{
		string Start, Eind;
		KiesKlasse SoortKlasse;
        KiesReisType SoortReisType;
        KiesRailcard RailcardType;
        KiesBetaalmethode BetaalmethodeType;

		public UIInfo (string StartPlaats, string EindBestemming, KiesKlasse Klasse, KiesReisType SoortReis, KiesRailcard Railcard, KiesBetaalmethode Betaalmethode)
		{
			this.Start = StartPlaats;
			this.Eind = EindBestemming;
            this.SoortKlasse = Klasse;
			this.SoortReisType = SoortReis;
			this.RailcardType = Railcard;
            this.BetaalmethodeType = Betaalmethode;
		}

		public string StartPlaats {
			get {
				return Start;
			}
		}

		public string EindBestemming {
			get {
				return Eind;
			}
		}

		public KiesKlasse Klasse {
			get {
                return SoortKlasse;
			}
		}

		public KiesReisType ReisType {
			get {
				return SoortReisType ;
			}
		}

		public KiesRailcard Railcard {
			get {
				return RailcardType;
			}
		}

		public KiesBetaalmethode Betaalmethode {
			get {
				return BetaalmethodeType;
			}
		}
	}
}

