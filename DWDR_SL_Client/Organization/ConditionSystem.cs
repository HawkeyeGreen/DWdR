using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWDR_SL_Client.Universum;
using System.IO;

namespace DWDR_SL_Client.Organization
{
    /* Conditionsystem
     * Der ConditionContainer enthält eine Sammlung von Conditions,
     * die in ConditionSegments organisiert sind.
     * dabei bildet der Container alle Conditionen ab,
     * die gemeinsam abgefragt werden.
     * 
     * Condition
     * Eine einzelne Bedingung. Sie kann entweder static sein,
     * dann enthält sie alles, was sie brauch, um zu überprüfen,
     * ob sie zu trifft,
     * oder sie ist dynamic, dann fordert sie eine bestimmte Info an.
     * 
     * ConditionSegment
     * Alle Conditions, die gemeinsam mit & verknüpft abgefragt werden,
     * Der Container fragt sukessive seine Segmente ab, um zu überprüfen,
     * ob EINE der Bedingungen zu trifft.
     * 
     */

    class ConditionContainer
    {
        public List<ConditionSegment> segments = new List<ConditionSegment>();

        public bool checkMe(Spaceobject possibleSpaceObjectTarget)
        {
            return checkSegment(segments, possibleSpaceObjectTarget);
        }

        public bool checkSegment(List<ConditionSegment> segmentsToCheck, Spaceobject possibleSpaceObjectTarget)
        {
            if(segmentsToCheck[0].checkAmITrue(possibleSpaceObjectTarget))
            {
                return true;
            }
            else if(segmentsToCheck.Count <= 1)
            {
                return false;
            }
            else
            {
                return checkSegment(segmentsToCheck.GetRange(1, segmentsToCheck.Count - 1), possibleSpaceObjectTarget);
            }
        }

        public ConditionContainer load(String targetPath)
        {
            StreamReader reader = new StreamReader(File.OpenRead(targetPath + "condition_container.cc"));
            if(reader.ReadLine().Contains("def Segment")) { segments.Add(ConditionSegment.parseSegment(reader)); }
            reader.Close();
            return this;
        }
    }

    class Condition
    {
        public bool neutralElement = false;

        public string targetType = "planet";
        public string conditionType = "check_Attribute";
        public string conditionSecondInformation = "exact";
        public string excpectationsType = "Integer";
        public string conditionAttribute = "isInVeil";

        public bool boolscheExpectation = false;
        public int integerExpectation;
        public string stringExpectation;


        public bool staticCondition = false;
        public Spaceobject staticTarget;

        public bool checkMe(Spaceobject possibleTarget)
        {
            if (neutralElement == false)
            {
                if (staticCondition)
                {
                    return checkMe_Static();
                }
                else
                {
                    return checkMe_Dynamic(possibleTarget);
                }
            }
            else
            {
                return true;
            }
        }

        public bool checkMe_Static()
        {
            if(targetType == "planet")
            {
                Planet planet = new Planet();
                planet.loadMe(staticTarget.getPath());
                return checkPlanet(planet);
            }
            else
            {
                return false;
            }
        }

        public bool checkMe_Dynamic(Spaceobject possibleTarget)
        {
            if(possibleTarget.getType() == targetType)
            {
                if(targetType == "planet")
                {
                    Planet planet = new Planet();
                    planet.loadMe(possibleTarget.getPath());
                    return checkPlanet(planet);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool checkPlanet(Planet planet)
        {
            #region IntegerCheck
            if (excpectationsType == "Integer")
            {
                if(conditionSecondInformation == "exact")
                {
                    if (planet.getIntegerValue(conditionAttribute) == integerExpectation)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if(conditionSecondInformation == "lower_than")
                {
                    if (planet.getIntegerValue(conditionAttribute) < integerExpectation)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if(conditionSecondInformation == "lower_OR_equal")
                {
                    if (planet.getIntegerValue(conditionAttribute) <= integerExpectation)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if(conditionSecondInformation == "higher_OR_equal")
                {
                    if (planet.getIntegerValue(conditionAttribute) >= integerExpectation)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if(conditionSecondInformation == "higher")
                {
                    if (planet.getIntegerValue(conditionAttribute) > integerExpectation)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else //unequal
                {
                    if (planet.getIntegerValue(conditionAttribute) != integerExpectation)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            #endregion
            else
            {
                return false;
            }
        }

        public static Condition parseCondition(StreamReader reader)
        {
            Condition condition = new Condition();


            return condition;
        }
    }

    class ConditionSegment
    {
        public List<Condition> conditions = new List<Condition>();

        public ConditionSegment()
        {
            Condition cond = new Condition();
            cond.neutralElement = true;
            conditions.Add(cond);
        }

        public bool checkAmITrue(Spaceobject possibleSpaceObjectTarget)
        {
            return binaryCheck(0, possibleSpaceObjectTarget);
        }

        public bool binaryCheck(int count, Spaceobject possibleSpaceObjectTarget)
        {
            if(conditions[count].checkMe(possibleSpaceObjectTarget))
            {
                if(count < conditions.Count -1)
                {
                    return binaryCheck(count + 1, possibleSpaceObjectTarget);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static ConditionSegment parseSegment(StreamReader reader)
        {
            ConditionSegment segment = new ConditionSegment();
            bool reading = true;
            while(reading)
            {
                string line = reader.ReadLine();
                if (line.Contains("def Condition"))
                {
                    segment.conditions.Add(Condition.parseCondition(reader));
                }
                else if(line.Contains("end Segment"))
                {
                    reading = false;
                }
            }
            return segment;
        }
    }
}
