library IEEE;
use IEEE.std_logic_1164.all; 

entity ic74283 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic74283 is "74xx";
	attribute component_name of ic74283 is "74HC283";
	attribute footprint_name of ic74283 is "Package_DIP:DIP-16_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 8;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 16;
	attribute pin_type of VCC is "power_in";

  CIN : in std_logic;
	attribute pin_assign of CIN is 7;
	attribute pin_type of CIN is "input";

  A1 : in std_logic;
	attribute pin_assign of A1 is 5;
	attribute pin_type of A1 is "input";
  A2 : in std_logic;
	attribute pin_assign of A2 is 3;
	attribute pin_type of A2 is "input";
  A3 : in std_logic;
	attribute pin_assign of A3 is 14;
	attribute pin_type of A3 is "input";
  A4 : in std_logic;
	attribute pin_assign of A4 is 12;
	attribute pin_type of A4 is "input";

  B1 : in std_logic;
	attribute pin_assign of B1 is 6;
	attribute pin_type of B1 is "input";
  B2 : in std_logic;
	attribute pin_assign of B2 is 2;
	attribute pin_type of B2 is "input";
  B3 : in std_logic;
	attribute pin_assign of B3 is 15;
	attribute pin_type of B3 is "input";
  B4 : in std_logic;
	attribute pin_assign of B4 is 11;
	attribute pin_type of B4 is "input";

  S1 : out std_logic;
  attribute pin_assign of S1 is 4;
  attribute pin_type of S1 is "output";
  S2 : out std_logic;
  attribute pin_assign of S2 is 1;
  attribute pin_type of S2 is "output";
  S3 : out std_logic;
  attribute pin_assign of S3 is 13;
  attribute pin_type of S3 is "output";
  S4 : out std_logic;
  attribute pin_assign of S4 is 10;
  attribute pin_type of S4 is "output";

  C4 : out std_logic;
  attribute pin_assign of C4 is 9;
  attribute pin_type of C4 is "output"
	);
	end ic74283;

architecture logic of ic74283 is 
  component comp74283
    port (
      CIN :  IN  STD_LOGIC;
      A1 :  IN  STD_LOGIC;
      A2 :  IN  STD_LOGIC;
      A3 :  IN  STD_LOGIC;
      A4 :  IN  STD_LOGIC;
      B1 :  IN  STD_LOGIC;
      B2 :  IN  STD_LOGIC;
      B3 :  IN  STD_LOGIC;
      B4 :  IN  STD_LOGIC;
      S1 :  OUT  STD_LOGIC;
      S2 :  OUT  STD_LOGIC;
      S3 :  OUT  STD_LOGIC;
      S4 :  OUT  STD_LOGIC;
      C4 :  OUT  STD_LOGIC
    );
  end component;
begin 

  inst : comp74283
    port map (
      CIN => CIN, 
      A1 => A1, 
      A2 => A2, 
      A3 => A3, 
      A4 => A4, 
      B1 => B1, 
      B2 => B2, 
      B3 => B3, 
      B4 => B4, 
      S1 => S1, 
      S2 => S2, 
      S3 => S3, 
      S4 => S4, 
      C4 => C4
    );

end logic;