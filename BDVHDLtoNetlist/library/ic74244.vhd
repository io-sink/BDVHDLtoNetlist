library IEEE;
use IEEE.std_logic_1164.all; 

entity ic74244 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic74244 is "74xx";
	attribute component_name of ic74244 is "74HC244";
	attribute footprint_name of ic74244 is "Package_DIP:DIP-20_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 10;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 20;
	attribute pin_type of VCC is "power_in";

	GN1 : in std_logic;
	attribute pin_assign of GN1 is 1;
	attribute pin_type of GN1 is "input";
	A11 : in std_logic;
	attribute pin_assign of A11 is 2;
	attribute pin_type of A11 is "input";
	A12 : in std_logic;
	attribute pin_assign of A12 is 4;
	attribute pin_type of A12 is "input";
	A13 : in std_logic;
	attribute pin_assign of A13 is 6;
	attribute pin_type of A13 is "input";
	A14 : in std_logic;
	attribute pin_assign of A14 is 8;
	attribute pin_type of A14 is "input";

	GN2 : in std_logic;
	attribute pin_assign of GN2 is 19;
	attribute pin_type of GN2 is "input";
	A21 : in std_logic;
	attribute pin_assign of A21 is 11;
	attribute pin_type of A21 is "input";
	A22 : in std_logic;
	attribute pin_assign of A22 is 13;
	attribute pin_type of A22 is "input";
	A23 : in std_logic;
	attribute pin_assign of A23 is 15;
	attribute pin_type of A23 is "input";
	A24 : in std_logic;
	attribute pin_assign of A24 is 17;
	attribute pin_type of A24 is "input";

  Y11 : out std_logic;
  attribute pin_assign of Y11 is 18;
  attribute pin_type of Y11 is "output";
  Y12 : out std_logic;
  attribute pin_assign of Y12 is 16;
  attribute pin_type of Y12 is "output";
  Y13 : out std_logic;
  attribute pin_assign of Y13 is 14;
  attribute pin_type of Y13 is "output";
  Y14 : out std_logic;
  attribute pin_assign of Y14 is 12;
  attribute pin_type of Y14 is "output";

  Y21 : out std_logic;
  attribute pin_assign of Y21 is 9;
  attribute pin_type of Y21 is "output";
  Y22 : out std_logic;
  attribute pin_assign of Y22 is 7;
  attribute pin_type of Y22 is "output";
  Y23 : out std_logic;
  attribute pin_assign of Y23 is 5;
  attribute pin_type of Y23 is "output";
  Y24 : out std_logic;
  attribute pin_assign of Y24 is 3;
  attribute pin_type of Y24 is "output"
	);
	end ic74244;

architecture logic of ic74244 is 
  component comp74244
    port (
      GN1 :  IN  STD_LOGIC;
      A11 :  IN  STD_LOGIC;
      A12 :  IN  STD_LOGIC;
      A13 :  IN  STD_LOGIC;
      A14 :  IN  STD_LOGIC;
      GN2 :  IN  STD_LOGIC;
      A21 :  IN  STD_LOGIC;
      A22 :  IN  STD_LOGIC;
      A23 :  IN  STD_LOGIC;
      A24 :  IN  STD_LOGIC;
      Y11 :  OUT  STD_LOGIC;
      Y12 :  OUT  STD_LOGIC;
      Y13 :  OUT  STD_LOGIC;
      Y14 :  OUT  STD_LOGIC;
      Y21 :  OUT  STD_LOGIC;
      Y22 :  OUT  STD_LOGIC;
      Y23 :  OUT  STD_LOGIC;
      Y24 :  OUT  STD_LOGIC
    );
  end component;

begin 

  inst : comp74244
    port map (
      GN1 => GN1, 
      A11 => A11, 
      A12 => A12, 
      A13 => A13, 
      A14 => A14, 
      GN2 => GN2, 
      A21 => A21, 
      A22 => A22, 
      A23 => A23, 
      A24 => A24, 
      Y11 => Y11, 
      Y12 => Y12, 
      Y13 => Y13, 
      Y14 => Y14, 
      Y21 => Y21, 
      Y22 => Y22, 
      Y23 => Y23, 
      Y24 => Y24
    );

end logic;