library IEEE;
use IEEE.std_logic_1164.all; 

entity ic74181 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic74181 is "74xx";
	attribute component_name of ic74181 is "74HC181";
	attribute footprint_name of ic74181 is "Package_DIP:DIP-24_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 12;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 24;
	attribute pin_type of VCC is "power_in";

  CN : in std_logic;
	attribute pin_assign of CN is 7;
	attribute pin_type of CN is "input";
  M : in std_logic;
	attribute pin_assign of M is 8;
	attribute pin_type of M is "input";

  S0 : in std_logic;
	attribute pin_assign of S0 is 6;
	attribute pin_type of S0 is "input";
  S1 : in std_logic;
	attribute pin_assign of S1 is 5;
	attribute pin_type of S1 is "input";
  S2 : in std_logic;
	attribute pin_assign of S2 is 4;
	attribute pin_type of S2 is "input";
  S3 : in std_logic;
	attribute pin_assign of S3 is 3;
	attribute pin_type of S3 is "input";

  A0N : in std_logic;
	attribute pin_assign of A0N is 2;
	attribute pin_type of A0N is "input";
  A1N : in std_logic;
	attribute pin_assign of A1N is 23;
	attribute pin_type of A1N is "input";
  A2N : in std_logic;
	attribute pin_assign of A2N is 21;
	attribute pin_type of A2N is "input";
  A3N : in std_logic;
	attribute pin_assign of A3N is 19;
	attribute pin_type of A3N is "input";

  B0N : in std_logic;
	attribute pin_assign of B0N is 1;
	attribute pin_type of B0N is "input";
  B1N : in std_logic;
	attribute pin_assign of B1N is 22;
	attribute pin_type of B1N is "input";
  B2N : in std_logic;
	attribute pin_assign of B2N is 20;
	attribute pin_type of B2N is "input";
  B3N : in std_logic;
	attribute pin_assign of B3N is 18;
	attribute pin_type of B3N is "input";
  
  F0N : out std_logic;
  attribute pin_assign of F0N is 9;
  attribute pin_type of F0N is "output";
  F1N : out std_logic;
  attribute pin_assign of F1N is 10;
  attribute pin_type of F1N is "output";
  F2N : out std_logic;
  attribute pin_assign of F2N is 11;
  attribute pin_type of F2N is "output";
  F3N : out std_logic;
  attribute pin_assign of F3N is 13;
  attribute pin_type of F3N is "output";

  CN4 : out std_logic;
  attribute pin_assign of CN4 is 16;
  attribute pin_type of CN4 is "output";
  AEQB : out std_logic;
  attribute pin_assign of AEQB is 14;
  attribute pin_type of AEQB is "output";
  PN : out std_logic;
  attribute pin_assign of PN is 15;
  attribute pin_type of PN is "output";
  GN : out std_logic;
  attribute pin_assign of GN is 17;
  attribute pin_type of GN is "output"
	);
	end ic74181;

architecture logic of ic74181 is 
  component comp74181
    port (
      CN :  IN  STD_LOGIC;
      M :  IN  STD_LOGIC;
      S0 :  IN  STD_LOGIC;
      S1 :  IN  STD_LOGIC;
      S2 :  IN  STD_LOGIC;
      S3 :  IN  STD_LOGIC;
      A0N :  IN  STD_LOGIC;
      A1N :  IN  STD_LOGIC;
      A2N :  IN  STD_LOGIC;
      A3N :  IN  STD_LOGIC;
      B0N :  IN  STD_LOGIC;
      B1N :  IN  STD_LOGIC;
      B2N :  IN  STD_LOGIC;
      B3N :  IN  STD_LOGIC;
      F0N :  OUT  STD_LOGIC;
      F1N :  OUT  STD_LOGIC;
      F2N :  OUT  STD_LOGIC;
      F3N :  OUT  STD_LOGIC;
      CN4 :  OUT  STD_LOGIC;
      AEQB :  OUT  STD_LOGIC;
      PN :  OUT  STD_LOGIC;
      GN :  OUT  STD_LOGIC
    );
  end component;

begin 

  inst : comp74181
    port map (
      CN => CN, 
      M => M, 
      S0 => S0, 
      S1 => S1,
      S2 => S2, 
      S3 => S3, 
      A0N => A0N, 
      A1N => A1N, 
      A2N => A2N, 
      A3N => A3N, 
      B0N => B0N, 
      B1N => B1N, 
      B2N => B2N, 
      B3N => B3N, 
      F0N => F0N, 
      F1N => F1N, 
      F2N => F2N, 
      F3N => F3N, 
      CN4 => CN4,
      AEQB => AEQB, 
      PN => PN, 
      GN => GN
    );

end logic;